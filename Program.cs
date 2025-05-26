namespace UTF_32_To_UTF_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** UTF-8 Encodeing Showcase ***\n");

            int[] codepoints = [0x000000A3, 0x0000007E, 0x0000039B, 0x00000E3F, 0x00000031, 0x0000263A];

            PrintUTF8Bytes(GetUTF8Bytes(0x000000A3));

            foreach (int codepoint in codepoints)
            {
                Console.WriteLine($"Codepoint \"{PrintUTF8Bytes(GetUNICODECodepoint(codepoint))}\" representing char \'{PrintUNICODEChar(codepoint)}\' encoded in UTF-8: \"{PrintUTF8Bytes(GetUTF8Bytes(codepoint))}\"");
            }
        }

        static byte[] GetUTF8Bytes(int codePoint)
        {
            string unicodeChar = char.ConvertFromUtf32(codePoint);
            return System.Text.Encoding.UTF8.GetBytes(unicodeChar);
        }

        static byte[] GetUNICODECodepoint(int codepoint)
        {
            string utf32Char = char.ConvertFromUtf32(codepoint);
            return System.Text.Encoding.GetEncoding("utf-32BE").GetBytes(utf32Char);
        }

        static string PrintUTF8Bytes(byte[] inputBytes)
        {
            return BitConverter.ToString(inputBytes).Replace("-", " ");
        }

        static char PrintUNICODEChar(int utf32codepoint)
        {
            return char.ConvertFromUtf32(utf32codepoint)[0];
        }
    }
}
