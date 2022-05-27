using System.Text.Json;
using PasswdGen.Models;

namespace PasswdGen.Service
{
    public class PasswdGenService
    {
        private const string ContainNumbers = "0123456789";
        private const string ContainUppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string ContainLowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string ContainSpchar = @"!""#$%&'()*+'-./:;<=>?@[\]^_`{|}~";
        public string passwdGen(bool containNumbers, bool containUppercase, bool containLowercase, bool containSpchar, int strLength, int count)
        {
            List<string> range = getRange(containNumbers, containUppercase, containLowercase, containSpchar, strLength, count);
            int[] randomNum = randomSelect(range.Count, strLength);
            string result = spliceString(range, randomNum, strLength, count);
            return JsonString(result);
        }

        public string JsonString(string value)
        {
            var jsonObject = new PasswdGenModel
            {
                Result = value
            };
            string jsonString = JsonSerializer.Serialize(jsonObject);
            return jsonString;
        }
        // 获取密码包含的元素范围
        public List<string> getRange(bool containNumbers, bool containUppercase, bool containLowercase, bool containSpchar, int strlength, int count)
        {
            List<string> range = new List<string>();
            if (containNumbers)
            {
                range.Add(ContainNumbers);
            }
            if (containUppercase)
            {
                range.Add(ContainUppercase);
            }
            if (containLowercase)
            {
                range.Add(ContainLowercase);
            }
            if (containSpchar)
            {
                range.Add(ContainSpchar);
            }
            return range;
        }
        // 随机分配不同组的抽取次数
        public int[] randomSelect(int arrlength, int strlength)
        {
            int[] randomNum = new int[arrlength];
            int sum = 0;
            do
            {
                // 给不同的数组分配随机抽取次数,保证符合条件的字符至少有一位
                sum = 0;
                for (int i = 0; i < arrlength; i++)
                {
                    randomNum[i] = Random.Shared.Next(1, strlength);
                    sum += randomNum[i];
                }
            }
            while (sum != strlength);
            return randomNum;
        }

        // 拼接并打乱字符串顺序
        public string spliceString(List<string> range, int[] randomNum, int strLength, int count)
        {
            // string temp = "";
            string result = "";
            for (int i = 0; i < count; i++)
            {
                string temp = "";
                for (int j = 0; j < randomNum.Length; j++)
                {
                    for (int k = 0; k < randomNum[j]; k++)
                    {
                        int index = Random.Shared.Next(range[j].Length);
                        temp += range[j].Substring(index, 1);
                    }
                }
                char[] arr = temp.ToCharArray();
                for (int l = strLength - 1; l >= 0; l--)
                {
                    int index = Random.Shared.Next(0, l);
                    result += arr[index];
                    arr[index] = arr[l];
                }
                result += "\n";
            }
            return result;
        }

    }

}