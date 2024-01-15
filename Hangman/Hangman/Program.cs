using System.Text.RegularExpressions;

namespace Hangman;

internal class Program
{
    //void si usa quando non ci si apetta nulla di ritorno, se non c'e void alla fine ci sarà un return
    public static void Main(string[] args)
    {
        string restart = "";
        //verificare l'input del player sia tra 'a' e 'z'. 
        var validCharacters = new Regex("^[A-Z]$");
        do
        {
            Console.Clear();

            string passed = "";
            string sure = "";
            string dificult = "";
          
            Console.WriteLine("Benvenuto nel gioco dell'impiccato di Andrea!");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Il programma selezionerà in automatico una parola casuale, ogni lettera verrà visualizzata come un trattino \"-\", dovrai immetere le lettere come nel gioco classico.");
            Console.WriteLine(string.Empty);

            do
            {
                while (dificult != "FACILE" && dificult != "MEDIO" && dificult != "DIFFICILE")
                {
                    Console.Write("Selezionare il livello di difficoltà (F = Facile - M = Medio - D = Difficile): ");
                    dificult = Console.ReadKey().Key.ToString().ToUpper();
                    Console.WriteLine(string.Empty);

                    if (dificult == "F")
                    {
                        dificult = "FACILE";
                    }
                    if (dificult == "M")
                    {
                        dificult = "MEDIO";
                    }
                    if (dificult == "D")
                    {
                        dificult = "DIFFICILE";
                    }

                    if (dificult != "FACILE" && dificult != "MEDIO" && dificult != "DIFFICILE")
                    {
                        Console.WriteLine(string.Empty);
                        Console.WriteLine($"{dificult} non è una difficoltà. Riprova!");
                        Console.WriteLine(string.Empty);
                    }
                }

                Console.WriteLine(string.Empty);
                Console.Write($"Hai selezionato {dificult} sei sicuro(S/N)? : ");

                sure = Console.ReadKey().Key.ToString().ToUpper();
                Console.WriteLine(string.Empty);

                if (sure == "S" || sure == "N")
                {
                    passed = "ok";
                }
                else
                {
                    Console.WriteLine(string.Empty);
                    Console.WriteLine($"La scelta {sure} non è valida! Devi scegliere o S che sta per SI o N che sta per NO.");
                }
            }
            while (sure == "n" || passed != "ok");

            Console.WriteLine(string.Empty);

            int lives = Dificult.Lives(dificult);

            Console.WriteLine($"Avrai {lives} vite a disposizione. Buona fortuna!");
            Console.WriteLine(string.Empty);

            Console.Write("Premi INVIO per iniziare!");
            Console.Read();

            //word è la stringa da usare e ciao che c'è tra le parentesi qaudre è il numero tirato a sorte da prendere nell'array. Prende una poarola casual edall'array
            string wordToGuess = Dificult.WordToGuess(dificult);

            // Lista di lettere provate dal player. List è come un array ma variabile ovvero uyn alist adi oggetti variabili
            List<string> letters = new();

            //Fino a quando il player ha vite il gioco continua. While continua a girare fino a quando la condizione non è vera
            while (lives != 0)
            {
                Console.WriteLine(string.Empty);
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

                var key = Console.ReadKey().Key.ToString().ToUpper(); //Più semplificato del metodo sopra. ToLower serve a trasformare in minuscola la lettera

                Console.WriteLine(string.Empty);

                //Il ! inverte il valore dell'espressione, ovvero in questo caso se il carattere è diverso da quello possibile
                if (!validCharacters.IsMatch(key))
                {
                    Console.WriteLine($"Il tasto {key} non è valido! Riprova!");
                    Console.WriteLine(string.Empty);
                    continue;
                }
                if (letters.Contains(key))
                {
                    Console.WriteLine("Hai già inserito questa lettera!");
                    Console.WriteLine(string.Empty);
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
                        Console.WriteLine($"La lettera {key} non è nella parola da indovinare. Hai ancora {lives} {placeholder}");
                        Console.WriteLine(string.Empty);
                    }
                }

                if (lives == 0)
                {
                    string validloose = "";

                    Console.WriteLine($" You have lost! The word was {wordToGuess}.");
                    Console.WriteLine(string.Empty);

                    do
                    {
                        Console.Write("Vuoi rigiocare (S/N) ? : ");

                        restart = Console.ReadKey().Key.ToString().ToUpper();
                        Console.WriteLine(string.Empty);

                        if (restart == "S" || restart == "N")
                        {
                            validloose = "ok";
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine($"La scelta {restart} non è valida! Devi scegliere o S che sta per SI o N che sta per NO.");
                            Console.WriteLine(string.Empty);
                        }
                    }
                    while (validloose != "ok");

                }
            }

            if (lives > 0)
            {
                string validwin = "";

                Console.WriteLine("Complimenti mi hai battuto!");
                Console.WriteLine(string.Empty);

                do
                {
                    
                    Console.Write("Vuoi rigiocare (S/N) ? : ");

                    restart = Console.ReadKey().Key.ToString().ToUpper();
                    Console.WriteLine(string.Empty);

                    if (restart == "S" || restart == "N")
                    {
                        validwin = "ok";
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine($"La scelta {restart} non è valida! Devi scegliere o S che sta per SI o N che sta per NO.");
                        Console.WriteLine(string.Empty);
                    }
                }
                while (validwin != "ok");
               
            }
        }
        while (restart == "S");
    }

}
