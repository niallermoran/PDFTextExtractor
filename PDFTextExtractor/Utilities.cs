using org.apache.poi.xssf.extractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PDFTextExtractor
{
    static class Utilities
    {
        internal static string CleanPDFText( string text)
        {
            //remove any whitespace from beginning and end of text
            text = text.Trim();

            return text;
        }
    }
}
