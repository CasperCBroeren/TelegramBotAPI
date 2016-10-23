using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomBot.Brain
{
    public class Memory
    {
        private List<Lexing> lexings = new List<Lexing>();
        private Dictionary<string, Meme> storage { get; set; } = new Dictionary<string, Meme>();
        public Memory(List<Lexing> listOfLexings)
        {
            lexings = listOfLexings;
        }

        public bool InsertMeme(Meme item)
        {
            if (storage.ContainsKey(item.Subject))
                storage[item.Subject] = item;
            else 
                storage.Add(item.Subject, item);

            return true;
        }

        internal bool ContainsMeme(string subject)
        {
            return storage.ContainsKey(subject);
        }

        internal List<string> AnalyseSentence(string text)
        {
            text = text.ToLower();
            List<string> means = new List<string>();
            foreach(Lexing l in lexings)
            {
                foreach(string part in l.Words)
                {
                    if (text.Contains(part))
                    {
                        means.Add(l.BaseMeaning);
                        break;
                    }
                }
            }
            return means;
        }

        internal Meme GetMeme(string token)
        {
            return storage[token];
        }
    }
}
