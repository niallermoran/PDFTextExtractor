using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using sun.util.resources.cldr.bn;
using org.omg.CORBA;
using TikaOnDotNet.TextExtraction;

namespace PDFTextExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            TextExtractor extractor = new TextExtractor();

            // the folder to look for PDF files
            string folderPath = AppContext.BaseDirectory;

#if DEBUG
            // using a different path for debugging
            folderPath = @"C:\pdf";
#endif

            Console.WriteLine( string.Format( "PDF Text Extractor will extract text from all PDF files in folder {0}", folderPath ));
            Console.WriteLine("Text will be stored in txt files within the same folder and will be automatically overwritten should they exist");
            Console.WriteLine("");
            Console.WriteLine("Press return to continue");
            Console.Read();

            // get a list of PDF files in this directory
            try
            {
                // get the folder this executable is running in
                DirectoryInfo currentFolder = new DirectoryInfo( folderPath );

                foreach ( FileInfo file in currentFolder.EnumerateFiles("*.pdf") )
                {
                    Console.WriteLine(string.Format("Extracting text from {0}", file.Name));
                    var result = extractor.Extract(file.FullName);

                    // write to a text file with the same name
                    string textFileName = string.Format("{0}{1}", file.Name.Replace(file.Extension,""), ".txt");
                    Console.WriteLine(string.Format("Creating file {0}", textFileName));
                    using (StreamWriter textFile = File.CreateText(string.Format(@"{0}\{1}", currentFolder.FullName, textFileName)))
                    {
                        textFile.WriteLine( Utilities.CleanPDFText( result.Text ));
                    }
                }
            }
            catch( Exception ex)
            {
                Console.WriteLine(string.Format("Sorry, we ran into a problem: {0}", ex.Message));
            }

            Console.WriteLine("Press return to continue");
            Console.Read();
        }
    }
}
