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
                    UI.PrintInvalidMsg();
                    continue;
                }

                if (bankOfWords.Contains(word)) //Verifies if the word is repeated
                {
                    UI.PrintRepeatedMsg(word);
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
            
            int maxTries = displayWord.Length + 3;
            int letterCount = 0;
            question = $"\nYou have {maxTries} guesses to find out the secret word.\nWord: {displayWord}.\n\nWhat are your guesses? ";

            while (letterCount < maxTries)
            {
                guessedLetter = UI.AskForNewInput(question, letterCount); //Calls the UI.AskForNewInput for the player to guess their letters

                if (guessedLetter.Length > 1)
                {
                    UI.PrintTooManyCharsMsg();
                    continue;
                }

                char glChar = guessedLetter[0];
                if (!Char.IsLetter(glChar))
                {
                    UI.PrintInvalidMsg();
                    continue;
                }

                if (string.IsNullOrEmpty(guessedLetter))
                {
                    UI.PrintInvalidMsg();
                    continue;
                }

                if (listOfRepeatedLetters.Contains(guessedLetter))
                {
                    UI.PrintRepeatedMsg(guessedLetter);
                    continue;
                }
                
                if (!pickedWord.Contains(guessedLetter))//Displays a message if the letter is NOT part of the secret word
                {
                    UI.PrintNotContainMsg(guessedLetter);
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
                UI.PrintWordStatus(displayWord);// Call UI.PrintWordStatus method to show the updated secret word to the players
                letterCount++;

                if (!displayWord.Contains("*")) //Win check
                {
                    UI.WinLoseGame(displayWord, pickedWord); //Call the UI.WinLoseGame method to display the status of the game to the players (WIN)
                    break;
                }
            }  //end while (letterCount < maxTries)

            UI.WinLoseGame(displayWord, pickedWord); //Call the UI.WinLoseGame method to display the status of the game to the players (LOSE)

        }

    }
}