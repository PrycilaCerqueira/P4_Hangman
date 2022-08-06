using System;

namespace P4_Hangman // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.GameHeadline(); //Calls the UI.GameHeadline to display the game name on the console

            //BLOCK 1 - List of words creation
            int numOfWords = 3;
            string word = "";
            string question = $"Create your own bank of words. Add {numOfWords} word.";
            
            List<string> bankOfWords = new List<string>(); //Creates and initializes the list named bankOfWords
            
            while (bankOfWords.Count < numOfWords)
            {
                word = UI.AskForNewInput(question, bankOfWords.Count); //Calls the UI.AskForNewInput for the player to create their bank of words

                if (String.IsNullOrWhiteSpace(word)) //Verifies if the word is empty, null, or spaces
                {
                    Console.WriteLine("Null and spaces are invalidy entries. Try again!");
                    continue;
                }

                if (bankOfWords.Contains(word)) //Verifies if the word is repeated
                {
                    Console.WriteLine("This word already exist in your list. Try again!");
                    continue;
                }

                bankOfWords.Add(word.ToUpper()); //Adds a lower case converted word to the list
            }

            UI.ShowBankOfWords(bankOfWords); //Calls the UI.ShowBankOfWords to print words to the console 

            bool confirmation = UI.YesNoAnswer(); //Calls the UI.YesNoAnswer to Confirm if the player would like to proceed in the game
            if (confirmation == false) 
            {
                Environment.Exit(0); //Exits the console, forcing the game to end 
            }
            Console.Clear();//Clear the console, so the player won't see the banck of words


            //BLOCK 2 - Pick a random word from the list
            Random rnd = new Random();
            int wordIndex = rnd.Next(bankOfWords.Count);
            string pickedWord = bankOfWords[wordIndex];


            //BLOCK 3 - Discover if a character is part of the picked word
            string guessedLetter;
            string displayWord = pickedWord;
            char[] displayWordChars = displayWord.ToCharArray(); //Converts the displayWord from String to a Character Array
            List<string> listOfRepeatedLetters = new List<string>(); //List to store all the guessed letters

            for (int i = 0; i < displayWordChars.Length; i++) //Hides the secret word 
            {
                displayWordChars[i] = '*';
            }
            displayWord = new string(displayWordChars); //Converts the hidden word from the Character Array to a String in order to display on the console
            
            int maxTries = displayWord.Length;
            int letterCount = 0;
            question = $"\nYou have {pickedWord.Length} guesses to find out the secret word.\nWord: {displayWord}.\n\nWhat are your guesses? ";

            while (letterCount < maxTries)
            {
                guessedLetter = UI.AskForNewInput(question, letterCount); //Calls the UI.AskForNewInput for the player to guess their letters

                //TODO: Check for multiple letters and numbers.

                if (string.IsNullOrEmpty(guessedLetter))
                {
                    Console.WriteLine("Null and spaces are invalidy entries. Try again!");
                    continue;
                }

                if (listOfRepeatedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine($"You already guessed the letter {guessedLetter.ToUpper()}. Try again!");
                    continue;
                }
                
                if (!pickedWord.Contains(guessedLetter))//Displays a message if the letter is NOT part of the secret word
                {
                    Console.WriteLine($"The letter {guessedLetter.ToUpper()} is not in the secret word.");
                }

                for (int letterIndex = 0; letterIndex < displayWord.Length; letterIndex++) //Verifies if the guesses are correct and slowly reveals the hidden word to the players
                {
                    if (guessedLetter == pickedWord[letterIndex].ToString())
                    {
                        displayWordChars[letterIndex] = Convert.ToChar(guessedLetter);
                    }
                }
                
                listOfRepeatedLetters.Add(guessedLetter);//Adds the guessed letter to the guessed letters list
                displayWord = new string(displayWordChars);
                Console.WriteLine($"Updated word: {displayWord}\n"); // Shows the updated secret word to the players
                letterCount++;

                if (!displayWord.Contains("*"))
                {
                    Console.Clear();
                    Console.WriteLine($"\nYou win!\nThe word was {pickedWord}");
                    break;
                }
            }  //end while (letterCount < maxTries)

            if (displayWord.Contains("*"))
            {
                Console.Clear();
                Console.WriteLine($"\nYou lose!\nThe word was {pickedWord}");
                
                displayWord = new string(displayWordChars);
                Console.WriteLine($"You guessed up to this point: {displayWord}");
            }

            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) 
            { 
            }
           


        }
    }
}