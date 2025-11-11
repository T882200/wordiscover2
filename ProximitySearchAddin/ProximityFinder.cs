// -------------------------------------------------------------------------
//
//  ProximityFinder - Main search engine
//
// -------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using SysRegex = System.Text.RegularExpressions;

namespace ProximitySearchAddin
{
    public static class ProximityFinder
    {
        public static Task FindProximity(
            string searchKey1,
            string searchKey2,
            bool caseSensitive,
            bool logicalNot,
            bool paraProximity,
            int wordThreshold,
            int paraThreshold,
            List<SearchResult> results,
            IProgress<int> progress,
            CancellationToken cancelToken)
        {
            return Task.Run(() =>
            {
                var paraVisitedCount = 0;
                int totalParaCount = DocumentHelpers.GetParagraphsCount();
                var pOpts = new ParallelOptions { CancellationToken = cancelToken };
                var regexOpts = caseSensitive ? SysRegex.RegexOptions.None : SysRegex.RegexOptions.IgnoreCase;

                // Create proximity search settings
                var prox = new ProxSearchSettings
                {
                    SearchKey = searchKey2,
                    CaseSensitive = caseSensitive,
                    LogicalNot = logicalNot,
                    ParaProximity = paraProximity,
                    WordThreshold = wordThreshold,
                    ParaThreshold = paraThreshold
                };

                // Get paragraph ranges if doing interparagraph search
                if (paraProximity)
                {
                    prox.ParaEndingRanges = new List<int>();
                    foreach (Word.Paragraph para in DocumentHelpers.ActiveDocument.Paragraphs)
                    {
                        prox.ParaEndingRanges.Add(para.Range.End);
                    }
                }

                var searchKeyRegex = new SysRegex.Regex(searchKey1, regexOpts);
                int resultNumber = 0;
                object lockObj = new object();

                Parallel.ForEach(DocumentHelpers.GetParagraphsEnumerator(),
                                 pOpts,
                                 (currentParagraph, loopState, index) =>
                {
                    pOpts.CancellationToken.ThrowIfCancellationRequested();
                    var paraRange = ((Word.Paragraph)currentParagraph).Range;

                    // Adjust range for interparagraph matching
                    if (prox.ParaProximity)
                    {
                        int lookaheadPosition = (int)index + prox.ParaThreshold;
                        int topRange = (lookaheadPosition > totalParaCount)
                            ? totalParaCount
                            : lookaheadPosition;
                        paraRange.End = prox.ParaEndingRanges[topRange - 1];
                    }

                    if (paraRange.Text != null)
                    {
                        IEnumerable<SysRegex.Match> matches = null;

                        if (!prox.LogicalNot)
                        {
                            var pattern1 = new SysRegex.Regex(searchKey1 + ".*?" + prox.SearchKey, regexOpts);
                            var pattern2 = new SysRegex.Regex(prox.SearchKey + ".*?" + searchKey1, regexOpts);

                            var matches1 = pattern1.Matches(paraRange.Text);
                            var matches2 = pattern2.Matches(paraRange.Text);
                            matches = matches1.OfType<SysRegex.Match>()
                                        .Concat(matches2.OfType<SysRegex.Match>())
                                        .Where(m => m.Success);
                        }
                        else
                        {
                            var pattern = new SysRegex.Regex(searchKey1, regexOpts);
                            matches = pattern.Matches(paraRange.Text).OfType<SysRegex.Match>();
                        }

                        lock (lockObj)
                        {
                            FinderHelpers.DoFindProximity(
                                matches,
                                paraRange.Start,
                                paraRange.End,
                                searchKeyRegex,
                                prox,
                                results,
                                ref resultNumber);
                        }
                    }

                    // Report progress
                    progress?.Report(Interlocked.Increment(ref paraVisitedCount));
                });
            }, cancelToken);
        }
    }
}
