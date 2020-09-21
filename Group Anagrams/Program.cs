using System;
using System.Collections.Generic;

namespace Group_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var strs = new string[] { "ddddddddddg", "dgggggggggg" }; // ["",""] "eat", "tea", "tan", "ate", "nat", "bat"
            var results = GroupAnagrams(strs);
            foreach(var res in results)
            {
                Console.WriteLine(string.Join(" ", res));
            }
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> results = new List<IList<string>>();
            Dictionary<string, List<string>> kvp = new Dictionary<string, List<string>>();

            foreach(string str in strs)
            {
                List<string> list = new List<string>();
                char[] charArray = new char[26];
                foreach(char ch in str)
                {
                    charArray[ch - 'a']++;
                }

                string key = string.Join("", charArray);
                list.Add(str);
                if (!kvp.ContainsKey(key)) kvp.Add(key, list);
                else
                {
                    list.AddRange(kvp[key]);
                    kvp[key] = list;
                }

            }

            foreach(var val in kvp.Values)
            {
                results.Add(val);
            }

            return results;
        }
    }
}
