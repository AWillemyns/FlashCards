using FlashCards.Models;
using System;
using System.Collections.Generic;

namespace FlashCards {

    class Program {
        static ConsoleColor defaultColor;

        static void Main(string[] args) {
            string ReturnValue = "";
            //string CategoryFilter = "";

            defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to the flashcardgame! This app will help you learn and remember concepts and other notions.");

            ReturnValue = StartGame();


            while (ReturnValue.ToUpper() != "X") {
                Console.WriteLine("What do you want to do next? (R)estart or (e)xit?");
                while ((ReturnValue.ToUpper() != "R") && (ReturnValue.ToUpper() != "X")) {
                    Console.Write("Choose either (R)estart or e(x)it.");
                    ReturnValue = Console.ReadLine();
                }
                StartGame();
            }
            Console.ReadLine();
        }

        private static string StartGame() {
            string ReturnValue = "";

            Console.WriteLine("Choose an area of interest to start.");
            List<Area> areas = new List<Area>() {
                new Area() { AreaName = "[E] Economics" },
                new Area() { AreaName = "[P] Programming" }
            };

            Console.WriteLine("[A] All");
            foreach (Area area in areas) {
                Console.WriteLine(area.AreaName);
            }
            Console.WriteLine("[X] Exit");
            Console.ForegroundColor = defaultColor;

            while ((ReturnValue.ToUpper() != "P") && (ReturnValue.ToUpper() != "E") && (ReturnValue.ToUpper() != "X")) {
                Console.Write("Choose a category or enter X to exit.");
                ReturnValue = Console.ReadLine();
            }

            Console.WriteLine(ReturnValue);
            List<FlashCard> cards = GetFlashCards(ReturnValue);

            // iterate through card and show the question
            foreach (FlashCard card in cards) {
                ReturnValue = "";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Question: " + card.Question);
                Console.ForegroundColor = defaultColor;
                Console.WriteLine("(Press any key to view the answer.)");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(card.Answer);
                Console.ForegroundColor = defaultColor;
                while ((ReturnValue.ToUpper() != "Y") && (ReturnValue.ToUpper() != "N")) {
                    Console.Write("Did you know the answer? (Y/N)");
                    ReturnValue = Console.ReadLine();
                }

                //AnswerKnown = Console.ReadLine();
                if (ReturnValue.ToUpper() == "Y") {
                    Console.WriteLine("Good for you!");
                } else if (ReturnValue.ToUpper() == "N") {
                    Console.WriteLine("You'll get it next time.");
                } else {
                    Console.WriteLine("Unvalid answer");
                }
            }
            Console.WriteLine("You ran through all the questions, very good!");
            return ReturnValue;
        }

        private static List<FlashCard> GetFlashCards(string ReturnValue) {
            List<FlashCard> cards = new List<FlashCard>(){
                new FlashCard(){ Question = "What is the difference between a class and a struct?", Answer = "A structure or struct can be thought of as a lightweight class type. It serves mainly to have value-based semantics, meaning it is used primarily to represent mathematical, geometrical and other 'atomical' entities. They can not be used to build a family of related entities, you can not inherit from a struct type.", Area = new Area{AreaCode = "P", AreaName ="Programming" }, Category = "C#"},
                new FlashCard(){ Question = "How can you declare optional parameters in C#?", Answer = "You set an argument or parameter as optional by giving it a default value in the method declaration. When the argument is omitted, the default value will be used.", Area = new Area{ AreaCode = "P", AreaName = "Programming" }, Category = "C#" },
                new FlashCard(){ Question = "What is the upper range limit of a C# int?", Answer = "2,147,483,647", Area = new Area { AreaCode = "P", AreaName = "Programming" }, Category = "C#" },
                new FlashCard(){ Question = "What is CAPEX?", Answer = "Capital expenses", Area = new Area(){ AreaCode = "E",  AreaName = "Economics" }, Category = "General" }
                };
            List<FlashCard> cardsToReturn = cards.FindAll(a => a.Area.AreaCode == ReturnValue);
            return cardsToReturn;
        }


    }
}
