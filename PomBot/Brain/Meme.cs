using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomBot.Brain
{
    public class Meme
    {
     
        public string Subject { get; set; }
        public string Class { get; set; }
        public Dictionary<string, Meme> Relations { get; set; } = new Dictionary<string, Meme>();
    }
}
