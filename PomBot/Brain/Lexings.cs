using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomBot.Brain
{
    /// <summary>
    ///  Lexing are a collection of (stemmed)words which are used to detect sentences
    /// </summary>
    public class Lexing
    {
        public string BaseMeaning { get; set; }
        public List<string> Words { get; set; } = new List<string>();

        public Lexing(string baseMeaning, params string[] args)
        {
            BaseMeaning = baseMeaning;
            foreach (string w in args)
            {
                if (!String.IsNullOrEmpty(w))
                    Words.Add(w.ToString());
            }
        }
    }
}
