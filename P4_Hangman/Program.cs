﻿using System;

namespace P4_Hangman // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("** Hangman Game **\n\n");

            //BLOCK 1 - List of words creation
            string word = "";
            List<string> bankOfWords = new List<string>(); //Creates and initializes the list named bankOfWords
            Console.Write($"Create your own back of words. Enter 10 words:\n");

            for (int wordCount = 1; wordCount <= 3; wordCount++) //Add words to the bankOfWords list
            {
                Console.Write(@$"{wordCount})");
                word = Console.ReadLine();

                //If TRUE loop again. If FALSE go to repeated word verification
                while (String.IsNullOrEmpty(word) || String.IsNullOrWhiteSpace(word)) //Verifies if the word is empty, null, or spaces
                {
                   
                    Console.WriteLine("Null and spaces are invalidy entries. Please, try again.");
                    Console.Write("Enter a valid word: ");
                    word = Console.ReadLine();
                
                }

                //If TRUE loop again. If FALSE go to Add word to the list
                while (bankOfWords.Contains(word)) //Verifies if the word is repeated
                {
                    Console.WriteLine("This word already exist in your list.");
                    Console.Write("Enter a new word: ");
                    word = Console.ReadLine();
                }

                bankOfWords.Add(word.ToLower()); //Adds a lower case converted word to the list

             }

            Console.WriteLine("\nHere are your saved words:");
            foreach (string item in bankOfWords) //Print the bankOfWords items for the player
            {
                Console.WriteLine(item);
            }

            string confirmation = "";
            Console.Write("\nAre you happy with your list? (Yes/No) ");
            confirmation = Console.ReadLine(); 
            
            while (confirmation.ToLower() != "yes" && confirmation.ToLower() != "no") //Confirms if the player entered a valid confirmation word
            {
                Console.Write("This is an invalid entry. Choose Yes or No to proceed: ");
                confirmation = Console.ReadLine();
            }
            if (confirmation.ToLower() == "no") //Confirms if the player would like to proceed in the game
            {
                Console.Write("Sorry to hear that! See you next time.");
                Environment.Exit(0); //Exits the console, forcing the game to end 
            }

            //BLOCK 2 - Pick a random word from the list
            Random randomWord = new Random();
            int wordIndex = randomWord.Next(bankOfWords.Count);
            string pickedWord = bankOfWords[wordIndex];

            Console.WriteLine(pickedWord);

            //BLOCK 3 - Discover if a character is part of the picked word
            //TODO: Try out String.IndexOf( ) and/or String.Contains( )
            string guessedLetter = "";
            Console.Write("Enter a letter: ");
            guessedLetter = Console.ReadLine();
            guessedLetter = guessedLetter.ToLower();
            Console.WriteLine(pickedWord.Contains(guessedLetter));
            Console.WriteLine(pickedWord.IndexOf(guessedLetter));

        }
    }
}