using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace grund
{
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Skriv in din text: ");
            string text = Console.ReadLine();
            int counter = 0;
            
            foreach (char letter in text)
            {
                if (letter == 'Å' || letter == 'å' || letter == 'Ä' || letter == 'ä' || letter == 'Ö' || letter == 'ö')
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                Console.WriteLine("Texten verkar vara på svenska");
            }
            else
            {
                Console.WriteLine("Texten verkar inte vara på svenska");
            }

            Console.WriteLine("Antal svenska bokstäver: " + counter);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Svenska()
        {
            using FakeConsole console = new FakeConsole("ÅåÄäÖö ÄäÖö Öö qwerty");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar vara på svenska",
            "Antal svenska bokstäver: 12"
            }, console.Lines);
        }

        [TestMethod]
        public void Danska()
        {
            using FakeConsole console = new FakeConsole("København er Danmarks hovedstad");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar inte vara på svenska",
            "Antal svenska bokstäver: 0"
            }, console.Lines);
        }
    }
}
