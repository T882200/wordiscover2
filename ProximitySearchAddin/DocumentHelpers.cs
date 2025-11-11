// -------------------------------------------------------------------------
//
//  DocumentHelpers - Calls made into the ActiveDocument
//
// -------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;

namespace ProximitySearchAddin
{
    public static class DocumentHelpers
    {
        private static Word.Application _application;

        public static void Initialize(Word.Application application)
        {
            _application = application;
        }

        public static Word.Document ActiveDocument
        {
            get
            {
                if (_application.Documents.Count > 0 && _application.ActiveDocument != null)
                {
                    return _application.ActiveDocument;
                }
                return null;
            }
        }

        public static Word.Range GetRange(int start, int end)
        {
            return ActiveDocument?.Range(start, end);
        }

        public static IEnumerable<object> GetParagraphsEnumerator()
        {
            return ActiveDocument?.Paragraphs.Cast<object>() ?? Enumerable.Empty<object>();
        }

        public static int GetParagraphsCount()
        {
            return ActiveDocument?.Paragraphs.Count ?? 0;
        }
    }
}
