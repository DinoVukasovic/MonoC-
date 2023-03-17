using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a directory if it doesn't exist
            string dirLocation = @"C:\Users\Zera\Desktop\FileExercise";

            if (!Directory.Exists(dirLocation))
            {
                Directory.CreateDirectory(dirLocation);
            }
            else
            {
                Console.WriteLine("Directory exists :)");
            }

            //Storing file name and file location into strings
            string fileName = "file.txt";
            string fileLocation = $"{dirLocation}\\{fileName}";

            //Creting a file if it doesn't exist
            if (!File.Exists(fileLocation))
            {
                FileStream stream = File.Create(fileLocation);
                stream.Flush();
                stream.Close();
            }

            //Creating a second file
            string sndFileName = "file2.txt";
            string sndFileLocation = $"{dirLocation}\\{sndFileName}";

            if (!File.Exists(sndFileLocation))
            {
                FileStream stream = File.Create(sndFileLocation);
                stream.Flush();
                stream.Close();
            }

            //Writing a text into a file
            using (StreamWriter writer = new StreamWriter(fileLocation))
            {
                writer.WriteLine("Bla bla lorem ipsum");
            }


            //Reading the text from a txt file
            using (StreamReader reader = new StreamReader(fileLocation))
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);

            }

            //read from file1 copy to file2
            using (StreamReader sr = new StreamReader(fileLocation))
            {
                using (StreamWriter sw = new StreamWriter(sndFileLocation))
                {
                    sw.WriteLine("iz prvog teksta je ovo; " + sr.ReadLine());
                }
            }

            //creating a new pdf document and writing in it
            PdfDocument document = new PdfDocument();
            PdfPage page = new PdfPage();
            document.AddPage(page);

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XImage image = XImage.FromFile("C:\\Users\\Zera\\Desktop\\FileExercise\\Kitty.jpg");
            
            XFont font = new XFont("Time New Roman", 14);
            XPoint point = new XPoint(40, 40);

            gfx.DrawString("Blablablalballblsbla", font, XBrushes.HotPink, point);
            gfx.DrawImage(image, 50, 50, 250, 250);
            document.Save("C:\\Users\\Zera\\Desktop\\FileExercise\\pdf.pdf");
            document.Dispose();

            Console.ReadLine();
            // lines comments
        }
       
    }
}
   
