List<Player> players = [];
Console.WriteLine("Enter the number of players");
int playersCount = int.Parse(Console.ReadLine());
PopulatePlayers(players, playersCount);
Console.WriteLine("Type the word to discover:");
string secreteWord = ReadHidingKeys();
Console.Clear();
Console.WriteLine("Enter the maximun attempts");
int maxIncorrectAttempts = int.Parse(Console.ReadLine());

Hangman hangmanInstance = new Hangman(secreteWord, maxIncorrectAttempts, players);
hangmanInstance.Play();
void PopulatePlayers(List<Player> players, int playersCount)
{
    int count = 0;
    while (count < playersCount)
    {
        Console.WriteLine("Enter the name of " + (count + 1) + "º player");
        string nome = Console.ReadLine();
        players.Add(new Player(nome));
        count++;

    }
}

string ReadHidingKeys()
{
    string password = string.Empty;
    ConsoleKey key;

    do
    {
        var keyInfo = Console.ReadKey(intercept: true);
        key = keyInfo.Key;

        if (key == ConsoleKey.Backspace && password.Length > 0)
        {
            Console.Write("\b \b"); // Remove the last character from the console
            password = password[0..^1]; // Remove the last character from the string
        }
        else if (!char.IsControl(keyInfo.KeyChar))
        {
            Console.Write(""); // Mask the character
            password += keyInfo.KeyChar;
        }
    } while (key != ConsoleKey.Enter);

    return password;
}
