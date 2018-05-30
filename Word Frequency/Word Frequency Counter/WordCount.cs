using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Frequency_Counter
{
    class WordCount
    {
        string word;
        int count;

        public WordCount(string term)
        {
            word = term;
            
        }

        public WordCount(string term, int number)
        {
            word = term;
            count = number;
        }

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public int Count
        {
            get { return count; }
            set { count++; }
        }
    }
}
