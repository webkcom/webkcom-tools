using System.Text.Json;
using PasswdGen.Models;

namespace PasswdGen.Service
{
    public class PasswdGenService
    {
        public string getResult(bool containNumbers, bool containLetters, bool containSymbols, int length)
        {
            // ResultModel resultString = new ResultModel();
            if (containNumbers && !containLetters && !containSymbols)
            {
                return JsonString(pureNumbers(length));
            }
            else if (containLetters && !containNumbers && !containSymbols)
            {
                return JsonString(pureLetters(length));
            }
            else if (containSymbols && !containNumbers && !containLetters)
            {
                return JsonString(pureSymbols(length));
            }
            else if (containNumbers && containLetters && !containSymbols)
            {
                return JsonString(numbersAddLetters(length));
            }
            else if (containNumbers && !containLetters && containSymbols)
            {
                return JsonString(numbersAddSymbols(length));
            }
            else if (!containNumbers && containLetters && containSymbols)
            {
                return JsonString(lettersAddSymbols(length));
            }
            else
            {
                return JsonString(mixAll(length));
            }
        }

        public string JsonString(string value)
        {
            var jsonObject = new ResultModel
            {
                result = value
            };
            string jsonString = JsonSerializer.Serialize(jsonObject);
            return jsonString;
        }

        public string pureNumbers(int length)
        {
            Random random = new Random();
            string numbers = "";
            for (int i = 0; i < length; i++)
            {
                numbers += random.Next(10).ToString();
            }
            return numbers;
        }

        public string pureLetters(int length)
        {
            Random random = new Random();
            string str1 = "";
            string str2 = "";
            int n1, n2 = 0;
            for (int i = 0; i < length; i++)
            {
                n1 = random.Next(26) + 65;
                n2 = random.Next(26) + 97;
                str1 += Convert.ToString((char)n1) + Convert.ToString((char)n2);
            }
            char[] arr = str1.ToCharArray();
            for (int j = length - 1; j >= 0; j--)
            {
                int index = random.Next(0, j);
                str2 += arr[index];
                arr[index] = arr[j];
            }
            return str2;
        }

        public string pureSymbols(int length)
        {
            Random random = new Random();
            string str1 = "";
            string str2 = "";
            int n1, n2, n3, n4 = 0;
            for (int i = 0; i < length; i++)
            {
                n1 = random.Next(15) + 33;
                n2 = random.Next(7) + 58;
                n3 = random.Next(6) + 91;
                n4 = random.Next(4) + 123;
                str1 += Convert.ToString((char)n1) + Convert.ToString((char)n2) + Convert.ToString((char)n3) + Convert.ToString((char)n4);
            }
            char[] arr = str1.ToCharArray();
            for (int j = length - 1; j >= 0; j--)
            {
                int index = random.Next(0, j);
                str2 += arr[index];
                arr[index] = arr[j];
            }
            return str2;
        }

        public string mixTwoString(int length, string value1, string value2)
        {
            // 算法改良-避免字符串过短时导致生成的字符串不符合条件
            Random random = new Random();
            string str = "";
            string _str = "";
            string str_1 = "";
            string str_2 = "";
            string str1 = value1;
            string str2 = value2;
            int n1, n2 = 0;
            do
            {
                n1 = random.Next(length);
                n2 = random.Next(length);
            }
            while ((n1 + n2 != length) || n1 == 0 || n2 == 0);
            if (value1 == "numbers" && value2 == "letters")
            {
                str_1 = pureNumbers(n1);
                str_2 = pureLetters(n2);
            }
            else if (value1 == "numbers" && value2 == "symbols")
            {
                str_1 = pureNumbers(n1);
                str_2 = pureSymbols(n2);
            }
            else if (value1 == "letters" && value2 == "symbols")
            {
                str_1 = pureLetters(n1);
                str_2 = pureSymbols(n2);
            }
            str = str_1 + str_2;
            char[] arr = (str).ToCharArray();
            for (int i = (str).Length - 1; i >= 0; i--)
            {
                int index = random.Next(0, i);
                _str += arr[index];
                arr[index] = arr[i];
            }
            return _str;
        }

        public string mixAll(int length)
        {
            Random random = new Random();
            string str = "";
            string _str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            int n1, n2, n3 = 0;
            do
            {
                n1 = random.Next(length);
                n2 = random.Next(length);
                n3 = random.Next(length);
            }
            while ((n1 + n2 + n3 != length) || n1 == 0 || n2 == 0 || n3 == 0);
            str1 = pureNumbers(n1);
            str2 = pureLetters(n2);
            str3 = pureSymbols(n3);
            str = str1 + str2 + str3;
            char[] arr = (str).ToCharArray();
            for (int l = (str).Length - 1; l >= 0; l--)
            {
                int index = random.Next(0, l);
                _str += arr[index];
                arr[index] = arr[l];
            }
            return _str;
        }

        public string numbersAddLetters(int length)
        {
            return valueAddValue(length, "numbers", "letters");
        }

        public string numbersAddSymbols(int length)
        {
            return valueAddValue(length, "numbers", "symbols");
        }

        public string lettersAddSymbols(int length)
        {
            return valueAddValue(length, "letters", "symbols");
        }

        public string valueAddValue(int length, string value1, string value2)
        {
            return mixTwoString(length, value1, value2);
        }
    }

}