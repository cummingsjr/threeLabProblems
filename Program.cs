/*
* Name: James Cummings
* Course: CSCI 1250, Section 001
* Assignment: Lab 6, threeLabProblems
* Date: October 21, 2026
* Description: Create an app for three lab problems, allowing the user to select which problem to run.
*/




int[] choice = { 1, 2, 3, 4, 5 };

string[] choiceNames =
{
    "The Grade Checker",
    "The Dice Table",
    "The Score Report",
    "All Three",
    "Quit"
};

Console.WriteLine("=== CSCI 1250 Lab 06 ===");

for (int i = 0; i < choice.Length; i++)
{
    Console.WriteLine($"{choice[i]}. {choiceNames[i]}");
}

Console.Write("Choose a number between 1 and 5: ");

if (int.TryParse(Console.ReadLine(), out int choices))
{
    if (choices == 1)
    {
        GradeChecker();
    }
    else if (choices == 2)
    {
        DiceTable();
    }
    else if (choices == 3)
    {
        ScoreReport();
    }
    else if (choices == 4)
    {
        GradeChecker();
        DiceTable();
        ScoreReport();
    }
    else if (choices == 5)
    {
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Invalid choice. Please choose 1-5.");
    }
}
else
{
    Console.WriteLine("Please enter a valid number.");
}

GradeChecker()
{
    Console.WriteLine("Grade Checker selected.");
}

diceTable()
{
    Console.WriteLine("Dice Table selected.");
}
ScoreReport()
{
    Console.WriteLine("Score Report selected.");
}
