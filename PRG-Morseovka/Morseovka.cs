using System.Globalization;
using System.Text;

class Morseovka
{
    // Překladový slovník pro znaky latinky
    private readonly Dictionary<char, string> latinToMorse = new Dictionary<char, string>
    {
        {'A', ".-"},
        {'B', "-..."},
        {'C', "-.-."},
        {'D', "-.."},
        {'E', "."},
        {'F', "..-."},
        {'G', "--."},
        {'H', "...."},
        {'I', ".."},
        {'J', ".---"},
        {'K', "-.-"},
        {'L', ".-.."},
        {'M', "--"},
        {'N', "-."},
        {'O', "---"},
        {'P', ".--."},
        {'Q', "--.-"},
        {'R', ".-."},
        {'S', "..."},
        {'T', "-"},
        {'U', "..-"},
        {'V', "...-"},
        {'W', ".--"},
        {'X', "-..-"},
        {'Y', "-.--"},
        {'Z', "--.."},
        {'0', "-----"},
        {'1', ".----"},
        {'2', "..---"},
        {'3', "...--"},
        {'4', "....-"},
        {'5', "....."},
        {'6', "-...."},
        {'7', "--..."},
        {'8', "---.."},
        {'9', "----."},
    };

    // Překladový slovník pro morseovu abecedu
    private readonly Dictionary<string, char> morseToLatin = new Dictionary<string, char>();

    // Konstruktor třídy, který vytvoří překladový slovník pro morseovu abecedu
    public Morseovka()
    {
        foreach (var item in latinToMorse)
        {
            morseToLatin.Add(item.Value, item.Key);
        }
    }

    // Metoda pro kódování textu do morseovy abecedy
    public string Encode(string text)
    {
        text = NormalizeText(text); // Ošetření textu (odstranění diakritiky, převod na velká písmena)

        char[] textChars = text.ToCharArray(); // Rozdělení textu na jednotlivé znaky
        string[] morseChars = new string[textChars.Length]; // Pole pro morseovu abecedu

        // Překódování jednotlivých znaků
        for (int i = 0; i < textChars.Length; i++)
        {
            if (latinToMorse.ContainsKey(textChars[i]))
            {
                morseChars[i] = latinToMorse[textChars[i]];
            }
            else
            {
                morseChars[i] = textChars[i].ToString();
            }
        }
        // Spojení jednotlivých symbolů morseovy abecedy do jednoho řetězce
        return string.Join(" ", morseChars);
    }

    // Metoda pro dekódování textu z morseovy abecedy
    public string Decode(string code)
    {
        string[] morseWords = code.Split(' '); // Rozdělení kódovaného textu na jednotlivá slova

        StringBuilder text = new StringBuilder(); // StringBuilder pro dekódovaný text

        // Překódování jednotlivých symbolů
        for (int i = 0; i < morseWords.Length; i++)
        {
            if (morseToLatin.ContainsKey(morseWords[i]))
            {
                text.Append(morseToLatin[morseWords[i]]);
            }
            else
            {
                text.Append(" "); // Nenalezen symbol v slovníku se považuje za mezeru
            }
        }
        return text.ToString();
    }

    // Privátní metoda pro ošetření textu (odstranění diakritiky, převod na velká písmena)
    private string NormalizeText(string text)
    {
        text = text.ToUpper();
        text = text.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        foreach (var x in text)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(x);
            }
        }
        return sb.ToString().Normalize(NormalizationForm.FormC);
    }
}