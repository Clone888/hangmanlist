
Console.WriteLine("Välj ett ord från listan med hjälp av siffran");
string[] wordlist = File.ReadAllLines("../../../ordlista.txt");
Console.WriteLine();



for (int i = 0; i < wordlist.Length; i++)
{
    Console.Write(i + 1 + ".");
    Console.WriteLine(wordlist[i]);
}

Console.WriteLine();

string? input = string.Empty;
int selected;

while (!int.TryParse(input, out selected) || selected >= wordlist.Length || selected == 0) // loops until we input a number
{
    input = Console.ReadLine(); // reads the input

}


string word = wordlist[selected - 1];

Console.WriteLine(word);



while (word.Length == 0)
{
    Console.WriteLine("Var vänlig och ange ett ord.");

    word = Console.ReadLine().ToLower();
}

var currentGuess = string.Empty;

while (currentGuess.Length < word.Length)
{
    currentGuess = currentGuess + "_";
}

var lives = 10;
var hasWon = false;



while (lives > 0 && !hasWon)
{
    Console.Clear();
    Console.WriteLine(currentGuess);
    Console.WriteLine("current lives: " + lives);
    Console.Write("Please enter a letter as a guess: ");
    var guess = Console.ReadLine().ToLower();
    var guessWasRight = false;

    if (guess == word)
    {
        hasWon = true;
        Console.WriteLine("You have won!");
        // om gissningen är samma som ordet så har vi vunnit (ändra så att while loopen avbryts genom att "hasWon" ska bli true.
        // annars går vi ner till "else" och kör loopen för att hitta bokstäver
    }
    else
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (guess == word[i].ToString())
            {
                currentGuess = currentGuess.Remove(i, 1).Insert(i, guess);
                guessWasRight = true;
            }
        }
        if (!guessWasRight)
        {
            lives--;
            if (lives == 0)
            {
                Console.WriteLine("You have lost!");
            }
        }
        if (currentGuess == word)
        {
            hasWon = true; // om vi har börjat fylla på med bokstäver men sen gissar hela ordet så ska loopen avbrytas genom hasWon blir true

            Console.WriteLine("You have won!");
        }
    }
}