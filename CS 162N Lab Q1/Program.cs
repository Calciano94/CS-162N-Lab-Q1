using System;

class Program
{
    static void Main()
    {
        // Problem 1
        Console.WriteLine("Problem 1 - Multiple Consonants");
        Console.WriteLine(PigLatinBasic("three"));
        Console.WriteLine();

        // Problem 2
        Console.WriteLine("Problem 2 - Capitalization");
        Console.WriteLine(PigLatin("Cooper"));
        Console.WriteLine();

        // Problem 3
        Console.WriteLine("Problem 3 - Punctuation");
        Console.WriteLine(PigLatin("orion!"));
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

    static bool IsVowel(char ch)
    {
        ch = char.ToLower(ch);
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }

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
    // Problem 1 ONLY (basic version)
    // ----------------------------
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
    static string PigLatin(string word)
    {
        string punctuation = "";
        bool wasCapital = false;

        // Handle punctuation
        if (word.Length > 0 && char.IsPunctuation(word[word.Length - 1]))
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
        string result = "";

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

    static string PigLatinSentence(string sentence)
    {
        string[] words = sentence.Split(' ');
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            result += PigLatin(words[i]);

            if (i < words.Length - 1)
            {
                result += " ";
            }
        }

        return result;
    }

    // ----------------------------
    // Problems 5–6 (Caesar Cipher)
    // ----------------------------
    static string ShiftCipher(string text, int shift)
    {
        string result = "";

        foreach (char ch in text)
        {
            if (char.IsUpper(ch))
            {
                char newChar = (char)((((ch - 'A') + shift + 26) % 26) + 'A');
                result += newChar;
            }
            else if (char.IsLower(ch))
            {
                char newChar = (char)((((ch - 'a') + shift + 26) % 26) + 'a');
                result += newChar;
            }
            else
            {
                result += ch;
            }
        }

        return result;
    }
}