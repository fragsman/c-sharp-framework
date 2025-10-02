using System.Text;

namespace AutomationFramework.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Returns a string of 'length' alphabetic characters. The range goes from from 0 to N, where N is the max number 
        /// according to the number of the digits given by length parameter. If 'length' is 4 then N will be 9999.
        /// <param name="length">length of the resulting string</param>
        /// </summary>
        public static string GetRandomStringOfNumbers(int length)
        {
            Random rnd = new Random();
            int topNumber = GetMaxNumberForDigits(length);
            return rnd.Next(0, topNumber).ToString();
        }

        /// <summary>
        /// Returns a string of 'length' numeric characters
        /// - Use the Random.NextDouble() method to generate a float (flt) that is between 0.0 and 1.0 and is inclusive.
        /// - Multiply flt with 25 and take the Floor of the result. 
        /// This will return an integer(shift) that is between 0 and 25 and is inclusive.
        /// - Add the shift integer to 65, which is the ASCII value of the character A.
        /// This will return an inclusive value between 65 and 90, which will be the ASCII value of some character.
        /// Converting that value to a character will return an uppercase character.
        /// </summary>
        /// <param name="length">length of the resulting string</param>
        /// <returns></returns>
        public static string GetRandomStringOfLetters(int length)
        {
            StringBuilder tempString = new StringBuilder();
            Random rnd = new Random();

            char letter;
            for (int i = 0; i < length; i++)
            {
                double flt = rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                tempString.Append(letter);
            }
            return tempString.ToString();
        }

        private static int GetMaxNumberForDigits(int length)
        {
            string tempNumber = "";
            for (int i = 0; i < length; i++)
            {
                tempNumber += "9";
            }
            int finalNumber = int.Parse(tempNumber);
            return finalNumber;
        }

        public static string ConvertToMoneyFormat(string raw_number)
        {
            //Output format $000.000 (entire part only)
            //1     1               $1
            //2     10              $10
            //3     100             $100
            //4     1000            $1,000
            //5     10000           $10,000
            //6     100000          $100,000
            //7     1000000         $1,000,000
            //8     10000000        $10,000,000
            //9     100000000       $100,000,000
            //10    1000000000      $1,000,000,000
            //11    10000000000     $10,000,000,000
            //12    100000000000    $100,000,000,000
            string result;
            string number;
            string symbol = "";
            if (raw_number[0].Equals('-')) //is negative
            {
                number = raw_number.Substring(1, raw_number.Length-1);
                symbol = "-";
            }
            else //is positive (no symbol expected)
            {
                number = raw_number;
            }
            int len = number.Length;
            switch (len)
            {
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: number = number.Insert(1, ","); break;
                case 5: number = number.Insert(2, ","); break;
                case 6: number = number.Insert(3, ","); break;
                case 7: number = number.Insert(4, ","); number = number.Insert(1, ","); break;
                case 8: number = number.Insert(5, ","); number = number.Insert(2, ","); break;
                case 9: number = number.Insert(6, ","); number = number.Insert(3, ","); break;
                case 10: number = number.Insert(7, ","); number = number.Insert(4, ","); number = number.Insert(1, ","); break;
                case 11: number = number.Insert(8, ","); number = number.Insert(5, ","); number = number.Insert(2, ","); break;
                case 12: number = number.Insert(9, ","); number = number.Insert(6, ","); number = number.Insert(3, ","); break;
            }
            result = symbol + "$" + number;
            return result;
        }

        //Converts a date to what is shown on WebSite screen. Currently the format is dd-MMM-yyyy
        public static string ConvertDateToOnScreenDateFormat(DateTime date)
        {
            return date.ToString("dd-MMM-yyyy");
        }
    }
}
