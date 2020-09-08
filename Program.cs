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


            //Input
            Console.Write("Skriv in din text: ");
            string text = Console.ReadLine();
            int counter = 0;
            int danishCounter = 0;
            
            //Calculation
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

            //Output
            if (counter > danishCounter)
            {
                Console.WriteLine("Texten verkar vara p� svenska");
            }
            else if (danishCounter > counter)
            {
                Console.WriteLine("Texten verkar vara p� danska");
            }
            else if (counter == 0 && danishCounter == 0)
            {
                Console.WriteLine("Texten verkar inte vara p� svenska eller danska");
            }
            else if (counter == danishCounter)
            {
                Console.WriteLine("Texten verkar vara p� svenska");
            }

            Console.WriteLine($"Antal svenska bokst�ver: {counter}, antal danska bokst�ver: {danishCounter}");
        }
    }

    //Tests

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
        [TestMethod]
        public void SvenskaOchDanska()
        {
            using FakeConsole console = new FakeConsole("����");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar vara p� svenska",
            "Antal svenska bokst�ver: 2, antal danska bokst�ver: 2"
            }, console.Lines);
        }
    }
}
