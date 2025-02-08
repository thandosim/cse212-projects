using System;
using System.Collections.Generic;



public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");
        var results = new List<string>();
        WildcardBinary("110*0*", results);
        // Console.WriteLine(WildcardBinary("110100",results));
        results.Sort();
        foreach(string item in results)
        {
            Console.WriteLine(item);
        }
        
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        
        var tempResults = new List<string>
        {
            pattern
        };

        BinaryString(tempResults);
        void BinaryString(List<string>tempResults)
        {
            if(tempResults.Count==0)
            {
                return;
            }
            for(int i=0;i<=tempResults.Count-1;i++)
            {
                string item = tempResults[i];
                int index = item.IndexOf('*');
                if(index!=-1)
                {
                    char[] characters = item.ToCharArray();
                    characters[index]='0';
                    tempResults.Add(new string(characters));
                    characters[index]='1';
                    tempResults.Add(new string(characters));
                }
                else
                {
                    results.Add(item);
                }
                tempResults.Remove(item);
            }
            BinaryString(tempResults);
        }        
        return;
        // return index;
    }
}
