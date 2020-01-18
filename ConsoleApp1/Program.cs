using java.io;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class PdfReader
    {
        public string GetStringFromPdfStream(Stream stream)
        {
            PDDocument doc = null;
            try
            {
                doc = PDDocument.load(new JavaIoWrapper(stream));
                PDFTextStripper stripper = new PDFTextStripper();
                return stripper.getText(doc);
            }
            finally
            {
                if (doc != null)
                {
                    doc.close();
                }
            }
        }

        public class JavaIoWrapper : InputStream
        {
            private Stream _underlyingStream;

            public JavaIoWrapper(Stream stream)
            {
                _underlyingStream = stream;
            }

            public override int read()
            {
                return _underlyingStream.ReadByte();
            }
        }
    }
}
