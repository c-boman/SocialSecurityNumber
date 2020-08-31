using System;
using System.Globalization;
using System.Linq;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            string socialSecurityNumber ="";
            if (args.Length > 0) //then the user already entered in their security number through cmd.
            {
                socialSecurityNumber = args[0];
                Console.WriteLine();
                writeCenteredText("You entered in the social security number: " + args[0]);
                
            }
            else //if the user didn't already enter in their security number at startup, then ask for it:
            {
                Console.Write("Enter your 10 digit social security number (YYMMDDXXX): ");

                socialSecurityNumber = Console.ReadLine();
                Console.Clear();
            }

            int age = 30;
            int userBirthday = int.Parse(socialSecurityNumber.Substring(0, 6));

            string birthDay = socialSecurityNumber.Substring(0, 6);

            DateTime birthDate = DateTime.ParseExact(birthDay, "yyMMdd", CultureInfo.InvariantCulture);

            age = DateTime.Now.Year - birthDate.Year;

            if(birthDate.Month > DateTime.Now.Month || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age -= 1;
            }

            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length-2, 1));
            
            string gender = genderNumber % 2 == 0 ? "Female" : "Male";

            Console.WriteLine();
            writeCenteredText("-------------------------------------------");
            Console.WriteLine();
            writeCenteredText($"This is a {gender}, and the age is {age}.");
            Console.WriteLine();
            writeCenteredText("-------------------------------------------");
            Console.ReadLine();
        }
        static void writeCenteredText(String text)
        {
            int winWidth = (Console.WindowWidth / 2) - (text.Length / 2);
            for (int i = 0; i < winWidth; i++)
            {
                text = " " + text;
            }
            Console.WriteLine(text);
        }
    }
}
