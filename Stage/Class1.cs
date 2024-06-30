using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage
{
    public class Stage
    {
        public string Stagecode { get; set; }
        public string Stagename { get; set; }
        public int Quantity { get; set; }

        public Stage(string stage, string stagename, int quantity)
        {
            Stagecode = stage;
            Stagename = stagename;
            Quantity = quantity;
        }
    }
}
