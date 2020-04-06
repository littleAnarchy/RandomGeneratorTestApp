using RandomGenerator.Web.Services.Interfaces;
using System;

namespace RandomGenerator.Web.Services
{
    public class HundredRangeRandomService : IRandomGenerator
    {
        public int GetRandomValue()
        {
            var random = new Random(); //instance of random is being created per request because if it used as a field, it would cause a concurrency problem
            return random.Next(1, 100);
        }
    }
}
