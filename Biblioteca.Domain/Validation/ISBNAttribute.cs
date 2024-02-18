using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Biblioteca.Domain.Validation
{
    public class ISBNAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var isbn = value as string;

            if (string.IsNullOrEmpty(isbn))
            {
                return true;
            }

            isbn = isbn.Replace("-", "").Replace(" ", "");

            if (isbn.Length != 10 && isbn.Length != 13)
            {
                return false;
            }

            return isbn.Length == 10 ? IsValidIsbn10(isbn) : IsValidIsbn13(isbn);
        }

        private bool IsValidIsbn10(string isbn)
        {
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                if (isbn[i] < '0' || isbn[i] > '9')
                {
                    return false;
                }
                sum += (10 - i) * (isbn[i] - '0');
            }

            char lastChar = isbn[9];
            if (lastChar != 'X' && (lastChar < '0' || lastChar > '9'))
            {
                return false;
            }

            if (lastChar == 'X')
            {
                sum += 10 * 1;
            }
            else
            {
                sum += lastChar - '0';
            }

            return sum % 11 == 0;
        }

        private bool IsValidIsbn13(string isbn)
        {
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = isbn[i] - '0';
                if (digit < 0 || digit > 9)
                {
                    return false;
                }
                sum += i % 2 == 0 ? digit : digit * 3;
            }

            int lastDigit = isbn[12] - '0';
            if (lastDigit < 0 || lastDigit > 9)
            {
                return false;
            }

            int check = (10 - sum % 10) % 10;
            return check == lastDigit;
        }
    }
}
