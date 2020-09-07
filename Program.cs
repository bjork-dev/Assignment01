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
                if (letter == '�' || letter == '�' || letter == '�' || letter == '�' || letter == '�' || letter == '�')
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                Console.WriteLine("Texten verkar vara p� svenska");
            }
            else
            {
                Console.WriteLine("Texten verkar inte vara p� svenska");
            }

            Console.WriteLine("Antal svenska bokst�ver: " + counter);
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
            "Antal svenska bokst�ver: 12"
            }, console.Lines);
        }

        [TestMethod]
        public void Danska()
        {
            using FakeConsole console = new FakeConsole("K�benhavn er Danmarks hovedstad");
            Program.Main();
            CollectionAssert.AreEqual(new[] {
            "Texten verkar inte vara p� svenska",
            "Antal svenska bokst�ver: 0"
            }, console.Lines);
        }
    }
}
