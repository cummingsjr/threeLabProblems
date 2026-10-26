/*
* Name: James Cummings
* Course: CSCI 1250, Section 001
* Assignment: Lab 6, threeLabProblems
* Date: October 21, 2026
* Description: Create an app for three lab problems, allowing the user to select which problem to run.
*/
int[] num = { 1, 2, 3, 4, 5 };

string[] apps =
{
    "The Grade Checker",
    "The Dice Table",
    "The Score Report",
    "All Three",
    "Quit"
};

Random rng = new Random(12345);
string selection = "";

while (selection != "Quit")
{
    Console.WriteLine("\n=== CSCI 1250 Lab 06 ===");

    for (int i = 0; i < num.Length; i++)
    {
        Console.WriteLine($"{num[i]}. {apps[i]}");
    }

    Console.Write("\nEnter your choice (1-5): ");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int choice) ||
        choice < 1 || choice > 5)
    {
        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
        continue;
    }

    selection = apps[choice - 1];

    if (selection == "The Grade Checker")
    {
        GradeChecker();
    }
    else if (selection == "The Dice Table")
    {
        DiceTable();
    }
    else if (selection == "The Score Report")
    {
        ScoreReport();
    }
    else if (selection == "All Three")
    {
        GradeChecker();
        DiceTable();
        ScoreReport();
    }
    else if (selection == "Quit")
    {
        Console.WriteLine("Goodbye!");
    }
}

void GradeChecker()
{
    Console.WriteLine("\n=== The Grade Checker ===");
    Console.Write("Enter a score (0-100): ");

    string? scoreInput = Console.ReadLine();

    if (!double.TryParse(scoreInput, out double score) ||
        score < 0 || score > 100)
    {
        Console.WriteLine("Invalid score. Enter a number from 0 to 100.");
        return;
    }

    string grade;

    if (score >= 90)
        grade = "A";
    else if (score >= 80)
        grade = "B";
    else if (score >= 70)
        grade = "C";
    else if (score >= 60)
        grade = "D";
    else
        grade = "F";

    Console.WriteLine($"Score: {score}");
    Console.WriteLine($"Letter Grade: {grade}");
}

void DiceTable()
{
    Console.WriteLine("\n=== The Dice Table ===");

    int rollCount = 0;
    int winCount = 0;
    string rollAgain = "y";

    while (rollAgain == "y")
    {
        int die1 = rng.Next(1, 7);
        int die2 = rng.Next(1, 7);
        int total = die1 + die2;

        rollCount++;

        Console.Write(
            $"Roll {rollCount}: {die1} and {die2}, total {total}.");

        if (die1 == 1 && die2 == 1)
        {
            Console.Write(" Snake eyes.");
        }
        else if (die1 == die2)
        {
            Console.Write(" Doubles!");
        }
        else if (total == 7)
        {
            Console.Write(" A winner.");
            winCount++;
        }

        Console.WriteLine();

        Console.Write("Roll again? (y/n): ");
        rollAgain = Console.ReadLine()?.Trim().ToLower() ?? "n";

        while (rollAgain != "y" && rollAgain != "n")
        {
            Console.Write("Please enter y or n: ");
            rollAgain = Console.ReadLine()?.Trim().ToLower() ?? "n";
        }
    }

    Console.WriteLine(
        $"You rolled {rollCount} times and won {winCount}.");
}

void ScoreReport()
{
    Console.WriteLine("\n=== The Score Report ===");

    int[] scores = new int[5];
    int total = 0;

    for (int i = 0; i < scores.Length; i++)
    {
        Console.Write($"\nEnter score {i + 1} (0-100): ");

        if (!int.TryParse(Console.ReadLine(), out int score) ||
            score < 0 || score > 100)
        {
            Console.WriteLine(
                "Invalid score. Enter a whole number from 0 to 100.");

            i--;
            continue;
        }

        scores[i] = score;
        total += score;
    }

    int highest = scores[0];
    int lowest = scores[0];

    for (int i = 1; i < scores.Length; i++)
    {
        if (scores[i] > highest)
            highest = scores[i];

        if (scores[i] < lowest)
            lowest = scores[i];
    }

    double average = (double)total / scores.Length;

    Console.WriteLine("\n=== Score Summary ===");
    Console.WriteLine($"Scores: {string.Join(", ", scores)}");
    Console.WriteLine($"Total: {total}");
    Console.WriteLine($"Average: {average:F2}");
    Console.WriteLine($"Highest Score: {highest}");
    Console.WriteLine($"Lowest Score: {lowest}");
}