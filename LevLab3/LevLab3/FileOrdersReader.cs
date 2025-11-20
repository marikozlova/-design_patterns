using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpecialLabs3
{
    internal class FileOrdersReader
    {
        private string _fileName;

        public FileOrdersReader(string fileName)
        {
            _fileName = fileName;
        }

        public DataFromOrders GetData()
        {
            string[] strings = File.ReadAllLines(_fileName);
            int size = int.Parse(strings[0]);
            int[] expireTimes = new int[size];
            int[,] times = new int[size + 1, size + 1];
            expireTimes = ParseLine(strings[1], size);

            for (int i = 0; i < size + 1; i++)
            {
                string currentLine = strings[i+2];
                int[] parseLine = ParseLine(currentLine, size+1);
                for (int j = 0; j < parseLine.Length; j++)
                {
                    times[i,j] = parseLine[j];
                }
            }
            DataFromOrders _newData = new DataFromOrders(expireTimes,times);
            return _newData;
        }

        public int[] ParseLine(string line, int size)
        {
            int[] parsedLine = new int[size];
            string[] splittedLine = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i<size;i++)
            {
                parsedLine[i] = int.Parse(splittedLine[i]);
            }
            return parsedLine;
        }
    }
}
