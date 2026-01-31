using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.problems
{
    internal class NestedStringArray
    {
        /*
         * Nested string array problem
         * print an arrray of elements that can have a nested array of elements
         * ex.
         * 0: 1
         * 1: 2
         * 2: 3
         * 3.0: blue
         * 3.1: yellow
         * 3.2: red
         * 4: test
        */
        public static readonly List<Object>  inputSample = new List<Object>()
        {
            "1",
            "2",
            new List<Object>(){
                "3.0",
                "3.1",
                new List<Object>(){
                    "3.2.1",
                    "3.2.2",
                    "3.2.3",
                },
                "3.3",
            },
            new List<Object>(){
                "4.0",
                "4.1",
                "4.2",
                "4.3",
            },
            "5",
        };
        public void printNestedList(Object element)
        {
            if (element is List<Object>)
            {
                foreach (var item in (element as List<Object>))
                {
                    printNestedList(item);
                }
            }
            else
            {
                Console.WriteLine(element);
            }
        }
    }
}
