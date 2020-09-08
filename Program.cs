using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment
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
            int danishCounter = 0;

            foreach (char letter in text)
            {
                if (letter == 'Å' || letter == 'å' || letter == 'Ä' || letter == 'ä' || letter == 'Ö' || letter == 'ö')
                {
                    counter++;
                }
                if (letter == 'Æ' || letter == 'æ' || letter == 'Ø' || letter == 'ø' || letter == 'Å' || letter == 'å')
                {
                    danishCounter++;
                }
            }

            if (counter > danishCounter)
            {
                Console.WriteLine("Texten verkar vara på svenska");
            }
            else if (danishCounter > counter)
            {
                Console.WriteLine("Texten verkar vara på danska");
            }
            else
            {
                Console.WriteLine("Texten verkar inte vara på svenska eller danska");
            }

            Console.WriteLine($"Antal svenska bokstäver: {counter}, antal danska bokstäver: {danishCounter}");
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
            "Antal svenska bokstäver: 12, antal danska bokstäver: 2"
            }, console.Lines);
        }

        [TestMethod]
        public void Danska()
        {
            using FakeConsole console = new FakeConsole("København er Danmarks hovedstad");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar vara på danska",
            "Antal svenska bokstäver: 0, antal danska bokstäver: 1"
            }, console.Lines);
        }
        [TestMethod]
        public void Engelska()
        {
            using FakeConsole console = new FakeConsole("Hello, World!");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar inte vara på svenska eller danska",
            "Antal svenska bokstäver: 0, antal danska bokstäver: 0"
            }, console.Lines);
        }
    }
}
