using System.Diagnostics;
using System.Text.Json;
using System; 
using System.Linq;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        HashSet<string> wordsSet = [.. words];
        List<string> pairsList = new List<string>();
        foreach(string word in wordsSet)
        {
            string reverse = new string(word.Reverse().ToArray());
            if(wordsSet.Contains(reverse) && (word!=reverse))
            {
                wordsSet.Remove(reverse);
                var pair = word + " & " + reverse;
                pairsList.Add(pair);
            }
        }
        string[] pairs = pairsList.ToArray();
        return pairs;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            Debug.WriteLine(fields[3]);
            if(degrees.ContainsKey(fields[3]))
            {
                degrees[fields[3]]++;
            }
            else
            {
                degrees[fields[3]] = 1;
            }     
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        word1=word1.Replace(" ", "").ToLower();
        word2=word2.Replace(" ", "").ToLower();
        if(word1.Length==word2.Length)
        {
            var dict1 = new Dictionary<Char, int>();
            var dict2 = new Dictionary<Char, int>();
            for (int i=0;i<word1.Length;i++)
            {
                if (dict1.ContainsKey(word1[i]))
                {
                    dict1[word1[i]]++;
                }
                else 
                {
                    dict1[word1[i]] = 1;
                }

                if (dict2.ContainsKey(word2[i]))
                {
                    dict2[word2[i]]++;
                }
                else 
                {
                    dict2[word2[i]] = 1;
                }
            }
            
            // foreach(Char c in word2)
            // {
            //     dict1[c]++;
            // }
            var count = 0;
            foreach(KeyValuePair<Char, int> k in dict1)
            {
                Debug.WriteLine(k.Key + " " + k.Value);
                if(dict1.ContainsKey(k.Key) && dict2.ContainsKey(k.Key) && k.Value==dict2[k.Key])
                {
                    count++;
                }
            }
            
            if(count == dict1.Count && count == dict2.Count)
            {
                return true;
            }
        }
        return false;
   }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}