// See https://aka.ms/new-console-template for more information

using System;
using MyLibrary.Core;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringTag = new StringTag("Hello, World!");
            var doubleTag = new DoubleTag(3.14);
            var listTag = new ListTag<StringTag> {};
            listTag.Add(new StringTag("test"));
            listTag.Add(stringTag);


            Console.WriteLine(stringTag);
            Console.WriteLine(doubleTag);
            Console.WriteLine(listTag);

            var compountTest = new CompoundTag {
                ["Name"] = new StringTag("Apple"),
                ["Price"] = new DoubleTag(3.99),
                ["Sizes"] = new ListTag<StringTag> {
                    new StringTag("Small"),
                    new StringTag("Medium"),
                    new StringTag("Large")
                }
            };

            Console.WriteLine(compountTest);
        }
    }
}
