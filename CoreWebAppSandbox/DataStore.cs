using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppSandbox
{
    public static class DataStore
    {
        private static readonly List<string> Data = new List<string>();

        public static IEnumerable<string> GetAll()
        {
            return Data;
        }

        public static string GetIndex(int index)
        {
            return Data[index];
        }

        public static void SetIndex(int index, string value)
        {
            Data[index] = value;
        }

        public static void Add(string value)
        {
            Data.Add(value);
        }

        public static void Delete(int index)
        {
            Data.RemoveAt(index);
        }
    }
}
