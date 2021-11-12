using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
     class Stock : TypeAliment
    {
        public DateTime ExpireLe { get; set; }

        public Stock(DateTime expireLe) : base(nom, unite)
        {
            ExpireLe = expireLe;
        }
    }
}
