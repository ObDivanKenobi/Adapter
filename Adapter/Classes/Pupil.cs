using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Classes
{
    public class Pupil
    {
        public string Name { get; set; }
        public string School { get; set; }
        public int Form { get; set; }
        public char? Litera { get; set; }
        public Dictionary<string, List<uint>> Grades { get; set; }
    }
}
