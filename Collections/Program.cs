using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // dictionaries are optimized for quick lookups
            // hashsets have slower writes than lists, but are optimized for reads
            // all Linq methods are immutable

            var strings = new List<string>()
            {
                "asdf",
                "blerg",
                "steve",
                "apple",
                "antelope",
                "xantelope"
            };

            strings.Add("blerg");
            strings.Contains("blerg");
            // strings.AddRange(); // take in a bunch of strings all at once

            var wordsBeginningWithA = strings
                .Where(currentString => currentString.StartsWith("a")); // essentially used like JavaScript's .filter() method

            var firstWord = strings.FirstOrDefault(currentString => currentString.StartsWith("a"));  // FirstOrDefault will provide 'null' if there isn't a match
            var secondWord = strings.Skip(1).Take(1); // or Skip(1).First(); to specifically get a string back

            // .DefaultIfEmpty() makes this item the default

            var anyWordsWithX = strings.Any(currentWord => currentWord.StartsWith("x"));
            var allWordsWithX = strings.All(currentWord => currentWord.StartsWith("x"));

            var transformed = strings.Select(item => $"{item} - transformed"); // works just like JavaScript's .map()
            var transformedAnimals = strings.Select(item => new Animal { Name = item });

            var letterAAnimals = strings
                .Where(currentString => currentString.StartsWith("a"))  // filter first
                .Select(item => new Animal { Name = item });  // then transform

            var groupedStrings = strings
                .GroupBy(currentString => currentString.First().ToString(),
                         currentString => new Animal { Name = currentString });

            strings.OrderBy(currentstring => currentstring.Last());
            strings.OrderByDescending(currentstring => currentstring.Last());

            // groupedStrings is a collection of IGrouping, IGroupings have keys and are also collections, but have no Value
            foreach (var grouping in groupedStrings)
            {
                Console.WriteLine($"I'm looping over the {grouping.Key} group");
                foreach (var currentString in grouping)
                {
                    Console.WriteLine($"{currentString} is in group {grouping.Key}");
                }
            }

            foreach (var currentString in strings)
            {
                Console.WriteLine($"Current string is {currentString}");
            }

            // var alphabetWords = new Dictionary<char, List<string>>();
            // alphabetWords.Add('a', new List<string>() { "asdf", "blerg", "steve" }; // {} is a collection initializer

            var alphabetWords = new Dictionary<char,string>();
            alphabetWords.Add('a', "apple");
            alphabetWords.Add('b', "baby");
            alphabetWords.Add('c', "catastrophe");

            var seven = alphabetWords['a'];
            alphabetWords['a'] = "dogastrophe";
           
            foreach (var word in alphabetWords)
            {
                Console.WriteLine($"The current key is {word.Key} and the value is {word.Value}");
            }

            // destructured version of above
            //foreach (var (key, value) in alphabetWords)
            //{
            //    Console.WriteLine($"The current key is {key} and the value is {value}");
            //}

            // iterating over a dictionary is essentially doing this:
            // var keyValues = new List<KeyValuePair<char, string>>();

            var hashset = new HashSet<Animal>();
            var tom = new Animal { Age = 12, Color = "golden", Name = "tom", Type = "dog" }; // can't add duplicates, hashsets only store 1 item per unique thing
            var jerry = new Animal { Age = 3, Color = "brown", Name = "jerry", Type = "elephant" }; // can't add duplicates, hashsets only store 1 item per unique thing
            
            hashset.Add(tom);
            hashset.Add(tom);
            hashset.Add(jerry);
        }

        class Animal
        {
            public string Name { get; set; }
            public string Color { get; set; }
            public string Type { get; set; }
            public int Age { get; set; }
        }
    }
}
