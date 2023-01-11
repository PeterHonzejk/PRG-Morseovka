class Program
{
    static void Main(string[] args)
    {
        // Vytvoření nové instance třídy Morseovka
        Morseovka morse = new Morseovka();

        // Kódování textu do morseovy abecedy
        string encodedText = morse.Encode("Ahoj svete");
        Console.WriteLine("Encoded text: " + encodedText);

        // Dekódování textu z morseovy abecedy
        string decodedText = morse.Decode(encodedText);
        Console.WriteLine("Decoded text: " + decodedText);

        Console.ReadKey();
    }
}