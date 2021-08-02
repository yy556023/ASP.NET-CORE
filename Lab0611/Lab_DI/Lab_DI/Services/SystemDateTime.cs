using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_DI.Services
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }

    public class SystemDateTime : IDateTime 
    {
        DateTime _time = DateTime.Now;
        public DateTime Now
        {
            get { return _time; }
        }
    }
}
