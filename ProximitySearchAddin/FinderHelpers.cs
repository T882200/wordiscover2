// -------------------------------------------------------------------------
//
//  FinderHelpers - Core proximity search logic
//
// -------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;
using SysRegex = System.Text.RegularExpressions;

namespace ProximitySearchAddin
{
    public class SearchResult
    {
        public Word.Range Range { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
    }

    public static class FinderHelpers
    {
        /// <summary>
        /// DoFindProximity - Core proximity search logic
        /// </summary>
        public static void DoFindProximity(IEnumerable<SysRegex.Match> matches,
                                            int startRange,
                                            int endRange,
                                            SysRegex.Regex searchKeyRegex,
                                            ProxSearchSettings prox,
                                            List<SearchResult> results,
                                            ref int resultNumber)
        {
            foreach (var match in matches)
            {
                var searchKeyMatch = searchKeyRegex.Match(match.Value);

                while (searchKeyMatch.Success)
                {
                    var pKeyRegOpts = prox.CaseSensitive ? SysRegex.RegexOptions.None : SysRegex.RegexOptions.IgnoreCase;
                    var proximityKeyRegex = new SysRegex.Regex(prox.SearchKey, pKeyRegOpts);
                    var searchKeyMatchEndpoint = searchKeyMatch.Index + searchKeyMatch.Length;

                    string beforeWords = GetProximityWords(match.Value.Substring(0, searchKeyMatch.Index), prox.WordThreshold, true);
                    string afterWords = GetProximityWords(match.Value.Substring(searchKeyMatchEndpoint), prox.WordThreshold, false);

                    var beforeMatch = proximityKeyRegex.Match(beforeWords);
                    var afterMatch = proximityKeyRegex.Match(afterWords);

                    var successPredicate = prox.LogicalNot
                                           ? (!beforeMatch.Success && !afterMatch.Success)
                                           : (beforeMatch.Success || afterMatch.Success);

                    while (successPredicate)
                    {
                        // Find where the match starts - before or after search key
                        int matchIndex = beforeMatch.Success
                            ? ((beforeWords.Length - beforeMatch.Index + 2) * -1)
                            : afterMatch.Success
                              ? afterMatch.Index + afterMatch.Length + 3
                              : 0;

                        int searchKeyIndex = startRange + match.Index + searchKeyMatch.Index;
                        int proxKeyIndex = searchKeyIndex + matchIndex;
                        int startIndex = searchKeyIndex < proxKeyIndex ? searchKeyIndex : proxKeyIndex;
                        int endIndex = searchKeyIndex > proxKeyIndex ? searchKeyIndex : proxKeyIndex;

                        AddResults(startIndex, endIndex + searchKeyMatch.Length, results, ref resultNumber);

                        if (!prox.LogicalNot)
                        {
                            beforeMatch = beforeMatch.NextMatch();
                            afterMatch = afterMatch.NextMatch();
                            successPredicate = (beforeMatch.Success || afterMatch.Success);
                        }
                        else break;
                    }
                    searchKeyMatch = searchKeyMatch.NextMatch();
                }
            }
        }

        public static void AddResults(int beginRangeMatch,
                                      int endRangeMatch,
                                      List<SearchResult> results,
                                      ref int resultNumber)
        {
            var rng = DocumentHelpers.GetRange(beginRangeMatch, endRangeMatch);
            if (rng != null)
            {
                // Get context (5 chars before and after)
                var beginContext = beginRangeMatch >= 5 ? (beginRangeMatch - 5) : beginRangeMatch;
                var doc = DocumentHelpers.ActiveDocument;
                var endContext = (endRangeMatch + 5) < doc.Content.End ? (endRangeMatch + 5) : doc.Content.End;
                var contextRange = DocumentHelpers.GetRange(beginContext, endContext);

                results.Add(new SearchResult
                {
                    Range = rng,
                    Text = contextRange?.Text ?? rng.Text,
                    Number = ++resultNumber
                });
            }
        }

        /// <summary>
        /// Get the pre/succeeding words based on proximity threshold
        /// </summary>
        public static string GetProximityWords(string words,
                                              int proxThreshold,
                                              bool beforeWords)
        {
            var wordlist = StripWhiteSpaceAndSpecialChars(words);
            Func<string, int, bool> predicate = beforeWords
                                                ? (Func<string, int, bool>)
                                                  ((word, wordIndex) => wordIndex > (wordlist.Count - proxThreshold - 1))
                                                : (word, wordIndex) => wordIndex < proxThreshold;
            return String.Join(" ", wordlist
                                     .Select((word) => word)
                                     .Where(predicate));
        }

        /// <summary>
        /// Get rid of extraneous whitespace and non-word characters
        /// </summary>
        public static List<string> StripWhiteSpaceAndSpecialChars(string str)
        {
            var pattern = @"\W\s+|\s{2,}";
            var patternRegex = new SysRegex.Regex(pattern);
            var match = patternRegex.Match(str);
            while (match.Success)
            {
                str = SysRegex.Regex.Replace(str, pattern, " ");
                match = match.NextMatch();
            }

            return str.Trim().Split(null).ToList();
        }
    }
}
