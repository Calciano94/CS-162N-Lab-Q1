using System;

class Program
{
    static void Main()
    {
        string word = "three";
        string result = PigLatinMultipleConsonants(word);
        Console.WriteLine("Original word: " + word);
        Console.WriteLine("Pig Latin: " + result);
    }

    static string PigLatinMultipleConsonants(string word)
    {
        string vowels = "aeiouAEIOU";
        int index = 0;

        while (index < word.Length && !vowels.Contains(word[index]))
        {
            index++;
        }

        if (index == 0)
        {
            return word + "way";
        }
        else
        {
            string beginning = word.Substring(0, index);
            string ending = word.Substring(index);
            return ending + beginning + "ay";
        }
    }
}
// final update