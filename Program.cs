using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRYPT input = new CRYPT();  //Create an input object from the CRYPT class 
            input.inputNumber();       // and call necessary functions
            input.printEncryptedNumber();
            input.printDecryptedNumber();
            Console.ReadLine();
        }
    }
    class CRYPT   //Define a CRYPT class
    {
        private int number; //Add number data member 
        public int Number   //  a related property for this class
        {
            get  //the get method returns the value of the variable 
            {
                return number;
            }
            set  //The set method assigns a value to the variable
            {
                number = value;  //the value keyword represents the value is assigned to the property
            }
        }
        public CRYPT()  //Define a default constructor with no parameters
        {
        }
        public CRYPT(int a)  //Define a constructor setting a valid number 
        {
            Number = a;
        }
        public void inputNumber()  //Define a method which inputs the number from the keyboard and checks whether it is valid or not
        {
            bool cont = true;  // use "bool" to check whether it is valid or not
            int truecount = 0;
            string x; //declare a string for input number
            while (cont)  // The while loop runs until the valid one is entered
            {
                Console.Write("Enter a four-digit number: ");
                x = Console.ReadLine();
                if (x.Length == 4) // these loops runs whether input entered from keyboard is wrong data
                {
                    for (int i = 0; i < x.ToString().Length; i++)  //the ToString() function converts an object to its string representation,
                    {                                              //so that the Length property returns the number of char objects
                        if ((char.IsNumber(x[i])))  //the IsNumber() function finds if the value is a numerical value or not
                        {
                            truecount += 1;
                        }
                    }
                    if (truecount == 4)  //when got four digit, the bool evaluates false 
                    {
                        cont = false;
                        Number = Convert.ToInt32(x);
                    }
                }
            }
        }
        public int[] encryptNumber()  //an encryption method that returns the encrypted number
        {
            int digit_1, digit_2, digit_3, digit_4;
            //to find every digit number
            digit_1 = (Number / 1000);
            digit_2 = (Number % 1000) / 100;
            digit_3 = (Number % 100) / 10;
            digit_4 = Number % 10;

            int[] array = { digit_1, digit_2, digit_3, digit_4 }; // declare an array for placing digits

            int[] arrayEncrypted = new int[4];  // declare an array for encrypted digits

            for (int i = 0; i < 4; i++)
            {
                arrayEncrypted[i] = (array[i] + 7) % 10; // replace each digit by (the sum of that digit plus 7) modulus 10.

            }
            //swap the first digit with the third, and swap the second digit with the fourth
            int t;   // declare an integer for swap
            t = arrayEncrypted[0];
            arrayEncrypted[0] = arrayEncrypted[2];
            arrayEncrypted[2] = t;

            t = arrayEncrypted[1];
            arrayEncrypted[1] = arrayEncrypted[3];
            arrayEncrypted[3] = t;

            return arrayEncrypted;
        }
        public int[] decryptNumber()  //a decryption method that inputs the encrypted number and returns the original number
        {
            int[] arr = { encryptNumber()[0], encryptNumber()[1], encryptNumber()[2], encryptNumber()[3] }; //declare an array for placing digits
            int[] original = new int[4];  //declare an array for decrypted digits

            for (int i = 0; i < 4; i++)
            {
                original[i] = (arr[i] + 3) % 10;
            }
            //swap operation 
            int n;
            n = original[0];
            original[0] = original[2];
            original[2] = n;

            n = original[1];
            original[1] = original[3];
            original[3] = n;

            return original;
        }
        public void printEncryptedNumber()  //a method that prints the encrypted number on the screen
        {
            Console.Write("Encrypted Message :");
            foreach (int i in encryptNumber())  //the foreach loop executes on each element in an array
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        public void printDecryptedNumber()  //a method that prints the decrypted number on the screen
        {
            Console.Write("Decrypted Message :");
            foreach (int i in decryptNumber())
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}