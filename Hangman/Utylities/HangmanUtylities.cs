using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman
{
    public static class Dificult
    {
        public static int Lives (string dificult)
        {
            int lives = 0;

            if (dificult == "FACILE")
            {
                lives = 8;
            }
            if (dificult == "MEDIO")
            {  
                lives = 7;
            }
            if (dificult == "DIFFICILE")
            {
                lives = 5;
            }
            return lives;
        }

        public static string WordToGuess(string dificult)
        {
            //array=lista di parole da prendere inizializzata
            string[] words = {};

            if (dificult == "FACILE")
            {
                string[] wordseasy = { "ciao", "ciao" };
                words = wordseasy;
            }
            if (dificult == "MEDIO")
            {
                string[] wordsmeadium = { "come" };
                words = wordsmeadium;
            }
            if (dificult == "DIFFICILE")
            {
                string[] wordshard = { "stai" };
                words = wordshard;
            }
            //Lenghth legge la lunghezza egli array si usa -1 perchè inizia a leggere da 1 invece l'array legge da 0. Prende un numero casuale
            int myRandomNumber = new Random().Next(0, words.Length - 1);

            //word è la stringa da usare e ciao che c'è tra le parentesi qaudre è il numero tirato a sorte da prendere nell'array. Prende una poarola casual edall'array
            string wordToGuess = words[myRandomNumber].ToUpper();

            return wordToGuess;
        }

    }
}
