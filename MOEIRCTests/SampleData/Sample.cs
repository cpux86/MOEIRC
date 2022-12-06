using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MOEIRCNet.API.Responses.Counters;

namespace MOEIRCTests.SampleData
{
    public class Sample
    {
        public static Task<string> Counters => File.ReadAllTextAsync(@"C:\C#\MOEIRC\MOEIRCTests\SampleData\counters.json");
        public static Task<string> Auth => File.ReadAllTextAsync(@"C:\C#\MOEIRC\MOEIRCTests\SampleData\auth.json");
        public static Task<string> Accounts => File.ReadAllTextAsync(@"C:\C#\MOEIRC\MOEIRCTests\SampleData\accounts.json");
    }
}
