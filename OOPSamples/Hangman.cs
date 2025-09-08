internal class Hangman
{
    private string secrete_word;
    private HashSet<char> correctChars = [];
    private HashSet<char> incorrectChars = [];
    private int remainingAttempts = 0;
    private List<Player> players = [];
    public Hangman(string secrete_word, int remainingAttempts, List<Player> players)
    {
        this.secrete_word = secrete_word.ToUpper();
        this.remainingAttempts = remainingAttempts;
        this.players = players;
    }
    public void Play()
    {
        Console.WriteLine("New Game started");
        int order = 0;
        while (remainingAttempts > 0 && !CompleteWord())
        {
            ShowStats();
            Console.Write(players[order].Name + ", enter a character \n");
            char enteredChar = char.ToUpper(Console.ReadKey().KeyChar);
            if (secrete_word.Contains(enteredChar))
            {
                correctChars.Add(enteredChar);
                players[order].Score += 10;
            }else
            {
                incorrectChars.Add(enteredChar);
                remainingAttempts--;
            }
            if(order < players.Count() - 1)
            {
                order++;
            } else
            {
                order = 0;
            }
        }
        if (CompleteWord())
        {
            Console.WriteLine("Congrats, you won: " + secrete_word);
        }else
        {
            Console.WriteLine("Game Over, correct word is: " + secrete_word);
        }
        foreach (var item in players)
        {
            Console.WriteLine(item.Name + " score: " + item.Score);
        }

    }
    private void ShowStats()
    {
        Console.WriteLine("\n");
        foreach (char c in secrete_word)
        {
            Console.Write(correctChars.Contains(c) ? c + " " : "_ ");
        }
        Console.WriteLine($"\nWrong Chars: {string.Join(", ", incorrectChars)}");
        Console.WriteLine($"\nRemaing Attempts: {string.Join(", ", remainingAttempts)}");
    }
    private bool CompleteWord()
    {
        foreach(char c in secrete_word)
        {
            if (!correctChars.Contains(c))
            {
                return false;
            }
        }
        return true;
    }
}