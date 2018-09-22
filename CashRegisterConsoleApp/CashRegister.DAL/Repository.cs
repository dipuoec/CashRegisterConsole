using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Utility;
using System.IO;

namespace CashRegister.DAL
{
    public class Repository
    {
        /// <summary>
        /// Data Access Layer . Assuming Text file is our DB and we are reading and writing from here.
        /// </summary>
        private static StreamWriter writeToTextFile = new StreamWriter("Receipts.txt");

        public void WriteToDataFile(string inputEntry)
        {
            //File.AppendAllText("Receipts.txt", inputEntry);

            writeToTextFile.WriteLine(inputEntry);
        }

        public void CloseFile()
        {
            writeToTextFile.Close();
        }

        public void ReadFromFile()
        {

            StreamReader readFromTextFile = new StreamReader("Receipts.txt");
            //New System.IO.TextReader extension that acts as a straw and sucks up every element from the text file

            string line = "";
            //Empty String

            while ((line = readFromTextFile.ReadLine()) != null)
            {
                //The empty string equals every line read from the text file while theres still text to read,
                //The process will remain active until the last line of the file is reached.

                Console.WriteLine(line);
                //Writes out every line to the console window

            }

        }

    }
}

