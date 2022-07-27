using System;

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

            for (int wordCount = 0; wordCount < 3; wordCount++) //Add words to the bankOfWords list
            {
                Console.Write(@$"{wordCount + 1})");
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
            Console.Write("\nAre you happy with your list? (Y/N) ");
            confirmation = Console.ReadLine(); 
            
            while (confirmation.ToLower() != "y" && confirmation.ToLower() != "n") //Confirms if the player entered a valid confirmation word
            {
                Console.Write("This is an invalid entry. Choose Y (yes) or N (no) to proceed: ");
                confirmation = Console.ReadLine();
            }
            if (confirmation.ToLower() == "n") //Confirms if the player would like to proceed in the game
            {
                Console.Write("Sorry to hear that! See you next time.");
                Environment.Exit(0); //Exits the console, forcing the game to end 
            }


            //BLOCK 2 - Pick a random word from the list
            Random rnd = new Random();
            int wordIndex = rnd.Next(bankOfWords.Count);
            string pickedWord = bankOfWords[wordIndex];


            //BLOCK 3 - Discover if a character is part of the picked word
            string guessedLetter;
            string displayWord = pickedWord;
            char[] displayWordChars = displayWord.ToCharArray(); //Converts the displayWord from String to a Character Array
            List<string> listOfRepeatedLetters = new List<string>(); //List to store all the guessed letters

            for (int i= 0; i < displayWordChars.Length; i++) //Hides the secret word 
            {
                displayWordChars[i] = '*';
            }
            displayWord = new string (displayWordChars); //Converts the hidden word from the Character Array to a String in order to display on the console
            Console.WriteLine($"\nYou have {pickedWord.Length} guesses to find out the secret word.\nWord: {displayWord}");

            int maxTries = displayWord.Length;
            for (int tryCount = 0; tryCount < maxTries; tryCount++) //Players input their letter guesses
            {
                Console.Write($"\n{tryCount + 1}) Guess a letter: ");
                guessedLetter = Console.ReadLine().ToLower();
                
                //TODO: the ELSE brings a new letter to the program, but it has passed the the array[0] check. Ex.: CASACO .... Array[0] didn't update, only Array[4].
                
                for (int letterIndex = 0; letterIndex < displayWord.Length; letterIndex++) //Verifies if the guesses are correct and slowly reveals the hidden word to the players
                {
                    if (listOfRepeatedLetters.Contains(guessedLetter)) //Confirms that the guessedLetter was NOT guessed yet
                    {
                        do
                        {
                            Console.WriteLine($"You already guessed the letter {guessedLetter.ToUpper()}. Try again!");
                            Console.Write("New letter: ");
                            guessedLetter = Console.ReadLine().ToLower();

                        } while (listOfRepeatedLetters.Contains(guessedLetter)); //Loops if the list contains the guessedLetter. If not, go to the next step 
                                                
                    }
                    if(!listOfRepeatedLetters.Contains(guessedLetter)) //If the letter WAS guessed, ask for a new one. 
                    {
                        if (guessedLetter == pickedWord[letterIndex].ToString())
                        {
                            displayWordChars[letterIndex] = Convert.ToChar(guessedLetter);
                        }
                    }
                }
                listOfRepeatedLetters.Add(guessedLetter); //Adds the guessed letter to the guessed letters list 

                if (!pickedWord.Contains(guessedLetter))//Displays a message if the letter is NOT part of the secret word
                {
                    Console.WriteLine($"The letter {guessedLetter.ToUpper()} is not in the secret word.");
                }
                             
                displayWord = new string(displayWordChars); //
                Console.WriteLine($"Updated word: {displayWord}"); // Shows the updated secret word to the players
                
            }

        }
            
            
        
            //BLOCK 4 - Draw the shape of the hangman

        
    }
}