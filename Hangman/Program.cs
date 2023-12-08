using System.Text.RegularExpressions;

namespace Hangman
{
    internal class Program
    {
        //void si usa quando non ci si apetta nulla di ritorno, se non c'e void alla fine ci sarà un return
        static void Main(string[] args)
        {
            //array=lista di parole da prendere
            string[] words = { "gaietta", "fukus", "yuki", "mamma", "puzzona", "nana", "dinosauro", "alice", "beayty", "pipina", "zucchina", "casa" };

            //verificare l'input del player sia tra 'a' e 'z'. 
            var validCharacters = new Regex("^[a-z]$");

            //Lenghth legge la lunghezza egli array si usa -1 perchè inizia a leggere da 1 invece l'array legge da 0. Prende un numero casuale
            int myRandomNumber = new Random().Next(0, words.Length - 1);

            //word è la stringa da usare e ciao che c'è tra le parentesi qaudre è il numero tirato a sorte da prendere nell'array. Prende una poarola casual edall'array
            string wordToGuess = words[myRandomNumber];

            //Numero di vite
            int lives = 3;

            // Lista di lettere provate dal player. List è come un array ma variabile ovvero uyn alist adi oggetti variabili
            List<string> letters = new();

            //Fino a quando il player ha vite il gioco continua. While continua a girare fino a quando la condizione non è vera
            while (lives != 0)
            {
                //contatore delle lettere che devono ancora essere indovinate
                int charactersLeft = 0;
                //Serve a mettere i trattini in base alle letetre della parola da indovinare
                //loop tra tutti i caratteri della parola scelta
                foreach (var character in wordToGuess)
                {
                    //trasforma qualsiasi variabile in stringa in questo caso character
                    var letter = character.ToString();

                    //se quel contenitore contiene la nostra lettera = Contains
                    if (letters.Contains(letter))
                    {
                        Console.Write(letter);
                    }

                    //altriemnti
                    else
                    {
                        //write non va a capo
                        Console.Write("_");

                        //incrementa di 1 le lettere da indovinare
                        charactersLeft++;

                    }
                }

                Console.WriteLine(String.Empty);

                if (charactersLeft == 0)
                {
                    break;
                }

                Console.Write("Digita una lettera: ");

                //aspetta la pressione da paret dell'utente di un tasto

                //var consoleKey = Console.ReadKey();

                //var key = consoleKey.Key;

                //var ourLetter = key.ToString();

                var key = Console.ReadKey().Key.ToString().ToLower(); //Più semplificato del metodo sopra. ToLower serve a trasformare in minuscola la lettera

                Console.WriteLine(String.Empty);

                //Il ! inverte il valore dell'espressione, ovvero in questo caso se il carattere è diverso da quello possibile
                if (!validCharacters.IsMatch(key))
                {
                    Console.WriteLine($"La lettera {key} non è valida. Riprova!");
                    continue;
                }
                if (letters.Contains(key))
                {
                    Console.WriteLine("Hai già digitato questa lettera!");
                    continue;
                }

                //Add aggiunge il tasto all'elenco dei tasti premuti
                letters.Add(key);

                //se la letterea non è corretta diminuisco di 1 la vita e scrivo qualcosa
                if (!wordToGuess.Contains(key))
                {
                    lives--;
                    
                    var placeholder = lives == 1 ? "vita rimanente" : "vite rimanenti";
                   

                    if (lives > 0)
                    {
                        Console.WriteLine($"La lettera {key} non è nella parola. Hai ancora {lives} {placeholder} !");
                    }
                    

                    //Metodo più lungo di quello sopra

                    //if (lives > 1)
                    //{
                    //    Console.WriteLine($"The letter {key} is not in the word to guess. You have {lives} lives left");
                    //}
                    //else if (lives == 1)
                    //{
                    //    Console.WriteLine($"The letter {key} is not in the word to guess. You have 1 life left");
                    //}
                }

                if (lives == 0)
                {
                    Console.WriteLine($"Hai perso! La parola era {wordToGuess}.");
                }
            }

        }
    }
}
