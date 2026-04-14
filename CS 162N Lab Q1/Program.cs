using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Problem 1
        Console.WriteLine("Problem 1 - Multiple Consonants");
        Console.WriteLine("Input: three → " + PigLatinBasic("three"));
        Console.WriteLine();

        // Problem 2
        Console.WriteLine("Problem 2 - Capitalization");
        Console.WriteLine("Input: Cooper → " + PigLatin("Cooper"));
        Console.WriteLine();

        // Problem 3
        Console.WriteLine("Problem 3 - Punctuation");
        Console.WriteLine("Input: orion! → " + PigLatin("orion!"));
        Console.WriteLine();

        // Problem 4
        Console.WriteLine("Problem 4 - Sentence to Pig Latin");
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();
        Console.WriteLine("Pig Latin: " + PigLatinSentence(sentence));
        Console.WriteLine();

        // Problem 5
        Console.WriteLine("Problem 5 - Caesar Cipher");
        Console.WriteLine("Shift +3: " + ShiftCipher("Hello", 3));
        Console.WriteLine("Shift -3: " + ShiftCipher("Hello", -3));
        Console.WriteLine();

        // Problem 6
        Console.WriteLine("Problem 6 - Sentence Caesar Cipher");
        Console.Write("Enter a phrase or sentence: ");
        string text = Console.ReadLine();

        Random rand = new Random();
        int shift = rand.Next(-10, 11);

        string encoded = ShiftCipher(text, shift);

        Console.WriteLine("Random shift: " + shift);
        Console.WriteLine("Encoded sentence: " + encoded);
    }

    // ----------------------------
    // Helper Methods
    // ----------------------------

    // Checks if a character is a vowel
    static bool IsVowel(char ch)
    {
        ch = char.ToLower(ch);
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }

    // Returns index of first vowel in a word
    static int IndexOfFirstVowel(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (IsVowel(word[i]))
            {
                return i;
            }
        }
        return -1;
    }

    // ----------------------------
    // Problem 1 (basic version)
    // ----------------------------

    // Converts a word to Pig Latin (basic version)
    static string PigLatinBasic(string word)
    {
        int index = IndexOfFirstVowel(word);

        if (index == 0)
        {
            return word + "way";
        }
        else if (index > 0)
        {
            string beginning = word.Substring(0, index);
            string ending = word.Substring(index);
            return ending + beginning + "ay";
        }
        else
        {
            return word + "ay";
        }
    }

    // ----------------------------
    // Problems 2–4 (full version)
    // ----------------------------

    // Converts a word to Pig Latin while preserving capitalization and punctuation
    static string PigLatin(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return "";
        }

        string punctuation = "";
        bool wasCapital = false;

        // Handle punctuation (last character)
        if (char.IsPunctuation(word[word.Length - 1]))
        {
            punctuation = word[word.Length - 1].ToString();
            word = word.Substring(0, word.Length - 1);
        }

        if (word.Length == 0)
        {
            return punctuation;
        }

        // Handle capitalization
        if (char.IsUpper(word[0]))
        {
            wasCapital = true;
            word = word.ToLower();
        }

        int index = IndexOfFirstVowel(word);
        string result;

        if (index == 0)
        {
            result = word + "way";
        }
        else if (index > 0)
        {
            string beginning = word.Substring(0, index);
            string ending = word.Substring(index);
            result = ending + beginning + "ay";
        }
        else
        {
            result = word + "ay";
        }

        if (wasCapital)
        {
            result = char.ToUpper(result[0]) + result.Substring(1);
        }

        return result + punctuation;
    }

    // Converts a full sentence into Pig Latin
    static string PigLatinSentence(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
        {
            return "";
        }

        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            result.Append(PigLatin(words[i]));

            if (i < words.Length - 1)
            {
                result.Append(" ");
            }
        }

        return result.ToString();
    }

    // ----------------------------
    // Problems 5–6 (Caesar Cipher)
    // ----------------------------

    // Shifts each letter in a string by a given amount (Caesar Cipher)
    static string ShiftCipher(string text, int shift)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return "";
        }

        StringBuilder result = new StringBuilder();

        foreach (char ch in text)
        {
            if (char.IsUpper(ch))
            {
                char newChar = (char)((((ch - 'A') + shift + 26) % 26) + 'A');
                result.Append(newChar);
            }
            else if (char.IsLower(ch))
            {
                char newChar = (char)((((ch - 'a') + shift + 26) % 26) + 'a');
                result.Append(newChar);
            }
            else
            {
                result.Append(ch);
            }
        }

        return result.ToString();
    }
}