using System;




public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");
        
        var results = new List<string>();
        PermutationsChoose(results, "ABCD",1);
        results.Sort();
        for(var i =0;i<results.Count;i++)
        {
            Console.WriteLine(results[i]);
        }
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        var resultsList = new List<string>();
        HashSet<string> resultsSet = new HashSet<string>();
        RemoveLettersFairly(letters, letters.Length-size, resultsList);
        foreach(string item in resultsList)
        {
            if(!resultsSet.Contains(item))
            {
                resultsSet.Add(item);
                Permute(item);
            }
        }

        void Permute(string letters, string word = "")
        {
            if (letters.Length == 0)
            {
                results.Add(word);
                // Console.WriteLine(word);
            }
            else
            {
                for (var i =0;i<letters.Length;i++)
                {
                    var lettersLeft = letters.Remove(i,1);
                    Permute( lettersLeft, word+letters[i]);
                }
            }
        }

        static void RemoveLettersFairly(string word, int n, List<string> results)
        {
            if (n == 0)
            {
                results.Add(word);
                return;
            }

            HashSet<string> seen = new HashSet<string>();
            for (int i = 0; i <= word.Length - n; i++)
            {
                string newWord = word.Remove(i, 1);
                if (!seen.Contains(newWord))
                {
                    seen.Add(newWord);
                    RemoveLettersFairly(newWord, n - 1, results);
                }
            }
            
        }  
    }
}