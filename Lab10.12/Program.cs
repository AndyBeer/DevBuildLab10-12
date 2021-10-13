using System;
using System.Collections.Generic;

namespace Lab10._12
{
    class Program
    {
        static void Main(string[] args)
        {
            //didnt have time to allow the user to search via name, but added fake favorite colors as an additional data point.
            List<int> studentNums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<string> names = new List<string>() { "Andy Beer", "Cassly Sullen", "Phil Conrad", "Zack Parr", "Cortez Christian", "Erin Walter", "Richard Moss", "James Mitchell", "Cullin Flynn", "Cordero Ebberhart" };
            List<string> hometowns = new List<string>() { "Berkley MI", "Detroit MI", "Canton MI", "Wyandotte MI", "Detroit MI", "Troy MI", "Canton MI", "Yap, FSM", "Fowlerville MI", "Berkley MI" };
            List<string> favFoods = new List<string>() { "French Fries", "Steak", "Fried Chicken", "Sushi", "Chicken Fettucine Alfredo", "Tacos", "Sushi", "Katsu", "Pad Thai", "BBQ" };
            List<string> favColors = new List<string>() { "red", "orange", "yellow", "green", "blue", "indigo", "violet", "turquoise", "purple", "maroon" };


            bool keepGoing1 = true;
            bool keepGoing2 = true;
            Console.WriteLine("Welcome to our C# class.  ");
            while (keepGoing1)
            {
                string studentSelection = GetInput("Which student would you like to learn more about ? (Enter a number 1 - 10): ");
                int userNum = ValidateAnswer(studentSelection);
                string studentName = names[userNum - 1];
                string hometown = hometowns[userNum - 1];
                string favFood = favFoods[userNum - 1];
                string favColor = favColors[userNum - 1];
                string moreInfo1;
                string studentFirst = studentName.Substring(0, studentName.IndexOf(" "));

                if (userNum > studentNums.Count)
                {
                    Console.WriteLine("That student does not exist.  Please Try again.  (Enter a number 1-20): ");
                }
                else
                {
                    Console.WriteLine($"Student {userNum} is {studentName}.");
                    keepGoing2 = true;

                    while (keepGoing2)
                    {
                        moreInfo1 = GetInput($"What would you like to know about {studentFirst}?  (Enter \"hometown\", \"favorite color\" or \"favorite food\"):  ");
                        if (moreInfo1.ToLower() == "hometown")
                        {
                            Console.Write($"{studentFirst} is from {hometown}.  ");
                            keepGoing2 = KnowMore("Would you like to know more? (Enter \"yes\" or \"no\")  ", "OK.\n  ");
                        }
                        else if (moreInfo1.ToLower() == "favorite food")
                        {
                            Console.Write($"{studentFirst}'s favorite food is {favFood}.  ");
                            keepGoing2 = KnowMore("Would you like to know more? (Enter \"yes\" or \"no\")  ", "OK.\n  ");
                        }
                        else if (moreInfo1.ToLower() == "favorite color")
                        {
                            Console.Write($"{studentFirst}'s favorite color is {favColor}.  ");
                            keepGoing2 = KnowMore("Would you like to know more? (Enter \"yes\" or \"no\")  ", "OK.\n  ");
                        }
                        else
                        {
                            Console.Write("That data does not exist.  Please try again.  \n");
                        }
                    }
                    
                }
                keepGoing1 = KnowMore("Would you like to learn about another student?  ", "Goodbye!");
            }

        }
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            string output = Console.ReadLine();
            return output;
        }
        public static int ValidateAnswer(string input)
        {
            int output;
            if (int.TryParse(input, out output) && output > 0)
            {
                return output;
            }
            else
            {
                input = GetInput("That is not a valid response.  Please Try again.  (Enter a number 1-20): ");
                return ValidateAnswer(input);
            }


        }
        public static bool KnowMore(string input, string message)
        {
            string answer = GetInput(input);
            if (answer.ToLower() == "yes")
            {
                return true;
            }
            else if (answer.ToLower() == "no")
            {
                Console.WriteLine(message);
                return false;
            }
            else
            {
                Console.WriteLine("That is not a valid response.\n");
                return KnowMore(input, message);
            }
        }
        
    }

}

