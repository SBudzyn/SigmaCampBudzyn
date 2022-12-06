using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7_Task2
{
    
    internal class LunaChecker
    {
        enum CardSystems
        {
            AmericanExpress,
            MasterCard,
            Visa,
            Invalid
        }
        //константи прийнято іменувати через всі літери великими.
        private const string Invalid = "INVALID";
        private const string AmericanExpress = "American Express";
        private const string MasterCard = "MasterCard";
        private const string Visa = "Visa";
        public static string Check(string cardNumber)
        {
            CardSystems system = ValidateCardSystem(cardNumber);
            if (system == CardSystems.Invalid)
            {
                return Invalid;
            }

            bool isLuna = LunaCheck(cardNumber);
            if (isLuna == false)
            {
                return Invalid;
            }
            else if (system == CardSystems.MasterCard)
            {
                return MasterCard;
            }
            else if (system == CardSystems.Visa)
            {
                return Visa;
            }
            else
            {
                return AmericanExpress;
            }
        }
        private static CardSystems ValidateCardSystem(string cardNumber)
        {
            if (!cardNumber.All(s => Char.IsDigit(s)))
            {
                return CardSystems.Invalid;
            }

            string strSystem = cardNumber.Substring(0, 2);
            if (cardNumber.Length == 15 && (strSystem == "34" || strSystem == "37"))
            {
                return CardSystems.AmericanExpress;
            }
            else if (cardNumber.Length == 16 && (strSystem == "51" || strSystem == "52" || strSystem == "53" || strSystem == "54" || strSystem == "55"))
            {
                return CardSystems.MasterCard;
            }
            else if ((cardNumber.Length == 13 || cardNumber.Length == 16) && strSystem[0] == '4')
            {
                return CardSystems.Visa;
            }
            else
            {
                return CardSystems.Invalid;
            }
        }
        private static bool LunaCheck(string cardNumber)
        {
            byte[] nums = new byte[cardNumber.Length];
            char[] charArray = cardNumber.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                nums[i] = byte.Parse(charArray[i].ToString());
            }

            for (int i = nums.Length - 2; i >= 0; i -= 2)
            {
                nums[i] *= 2;
                if (nums[i] > 9)
                {
                    nums[i] = (byte)((nums[i] / 10) + (nums[i] % 10));
                }
            }

            byte sum = 0;
            // можна простіше
            nums.ToList().ForEach(x => sum += x);
            if (sum % 10 == 0)
            {
                return true;
            //else не потрібно
            else
            {
                return false;
            }
        }
    }
}
