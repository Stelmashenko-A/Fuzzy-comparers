using System;
using System.Text;

namespace StringCrushLibrary
{
    public class StringCrusher
    {
        public StringCrusher(double removedLettersMaxPercent, double changedLettersMaxPercent,
            double addedLettersMaxPercent)
        {
            RemovedLettersMaxPercent = removedLettersMaxPercent;
            ChangedLettersMaxPercent = changedLettersMaxPercent;
            AddedLettersMaxPercent = addedLettersMaxPercent;
        }

        private static string _chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";

        private readonly Random _random = new Random();
        public double RemovedLettersMaxPercent { get; set; }

        public double ChangedLettersMaxPercent { get; set; }

        public double AddedLettersMaxPercent { get; set; }

        public string CrushString(string str)
        {
            var removedLetters = _random.Next(((int) (str.Length*RemovedLettersMaxPercent/100)) + 1);
            var changedLetters = _random.Next(((int) (str.Length*ChangedLettersMaxPercent/100)) + 1);
            var addedLetters = _random.Next(((int) (str.Length*AddedLettersMaxPercent/100)) + 1);
            var sb = new StringBuilder(str);
            for (var i = 0; i < addedLetters; i++)
            {
                var extraLetter = _chars[_random.Next(_chars.Length - 1)];
                var position = _random.Next(sb.Length - 1);
                sb.Insert(position, extraLetter);
            }

            for (var i = 0; i < changedLetters; i++)
            {
                var newLetter = _chars[_random.Next(_chars.Length - 1)];
                var position = _random.Next(sb.Length - 1);
                sb[position] = newLetter;
            }

            for (var i = 0; i < removedLetters; i++)
            {
                var position = _random.Next(sb.Length - 1);
                sb.Remove(position, 1);
            }

            return sb.ToString();
        }
    }
}