using System;
using System.Collections.Generic;

// Solving a rotational ciper. One private function where you input text to encode and an amount to shift that text.
// Two private functions that build a dictionary key and another that decodes that key.  
// Should be easy to change the dictionary encoding scheme for other functionality.
public static class RotationalCipher
{
    private static int shiftKey;
    private static IDictionary<char, char> cipherKey = new Dictionary<char, char>();

    public static string Rotate(string _rotateText, int _shiftKey)
    {
        shiftKey = _shiftKey;

        // Cipher is the alphabet.  Perform addition twice for upper and lower case.
        string cipherPlain = "abcdefghijklmnopqrstuvwxyz";
        AddtoCipher(cipherPlain);
        AddtoCipher(cipherPlain.ToUpper());

        // Builds the cipher.
        return BuildCipher(_rotateText);
    }

    private static void AddtoCipher(string cipherPlain)
    {
        // Shifts by each letter in the alphabet.
        int shift = 0;

        for (int i = 0; i < cipherPlain.Length; i++)
        {
            shift = (i + shiftKey) % cipherPlain.Length;
            cipherKey[cipherPlain[i]] = cipherPlain[shift];
        }
    }

    private static string BuildCipher(string _rotateText)
    {
        // Uses stringbuilder because a string is non-mutable.
        System.Text.StringBuilder final_text = new System.Text.StringBuilder(_rotateText);

        for (int i = 0; i < _rotateText.Length; i++)
        {
            if (cipherKey.ContainsKey(_rotateText[i]))
                final_text[i] = cipherKey[_rotateText[i]];
        }
        return final_text.ToString();
    }
}