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
                if (letter == '�' || letter == '�' || letter == '�' || letter == '�' || letter == '�' || letter == '�')
                {
                    counter++;
                }
                if (letter == '�' || letter == '�' || letter == '�' || letter == '�' || letter == '�' || letter == '�')
                {
                    danishCounter++;
                }
            }

            if (counter > danishCounter)
            {
                Console.WriteLine("Texten verkar vara p� svenska");
            }
            else if (danishCounter > counter)
            {
                Console.WriteLine("Texten verkar vara p� danska");
            }
            else
            {
                Console.WriteLine("Texten verkar inte vara p� svenska eller danska");
            }

            Console.WriteLine($"Antal svenska bokst�ver: {counter}, antal danska bokst�ver: {danishCounter}");
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Svenska()
        {
            using FakeConsole console = new FakeConsole("������ ���� �� qwerty");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar vara p� svenska",
            "Antal svenska bokst�ver: 12, antal danska bokst�ver: 2"
            }, console.Lines);
        }

        [TestMethod]
        public void Danska()
        {
            using FakeConsole console = new FakeConsole("K�benhavn er Danmarks hovedstad");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar vara p� danska",
            "Antal svenska bokst�ver: 0, antal danska bokst�ver: 1"
            }, console.Lines);
        }
        [TestMethod]
        public void Engelska()
        {
            using FakeConsole console = new FakeConsole("Hello, World!");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar inte vara p� svenska eller danska",
            "Antal svenska bokst�ver: 0, antal danska bokst�ver: 0"
            }, console.Lines);
        }
    }
}
