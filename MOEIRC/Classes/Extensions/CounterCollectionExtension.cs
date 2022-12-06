using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOEIRCNet.Classes.Extensions
{
    public static class CounterCollectionExtension
    {
        public static Counter GetCounterById(this IEnumerable<Counter> counters, string counterId)
        {
            return counters.FirstOrDefault(c => c.CounterNumber == counterId) ??
                   throw new Exception("Counter not fount");
        }
    }
}
