using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;


// 1. Prompt the user to input their name and birthdate
Console.Write("Enter your name: ");
string name = Console.ReadLine();

Console.Write("Enter your birthdate (MM/dd/yyyy): ");
string birthdateInput = Console.ReadLine();

// 2. Validate the birthdate format using a regular expression
if (!Regex.IsMatch(birthdateInput, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/(\d{4})$"))
{
    Console.WriteLine("Invalid date format. Please use MM/dd/yyyy.");
    return;
}
else{
    Console.WriteLine($"The date '{birthdateInput}' is valid");
}

int age = 0;

// 3. Calculate and display the user's age based on the birthdate
DateTime birthdate;
if (DateTime.TryParseExact(birthdateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthdate))
{
    age = DateTime.Now.Year - birthdate.Year;
    if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
    {
        age--;
    }
    Console.WriteLine($"Hello, {name}. You are {age} years old.");
}
else
{
    Console.WriteLine("Error parsing birthdate.");
    return;
}

// 4. Save the user's information to a file named "user_info.txt"
string userInfo = $"Name: {name}\nBirthdate: {birthdateInput}\nAge: {age}";
File.WriteAllText("user_info.txt", userInfo);
Console.WriteLine("User information saved to 'user_info.txt'.");

// 5. Read and display the contents of the "user_info.txt"
string readUserInfo = File.ReadAllText("user_info.txt");
Console.WriteLine("Contents of 'user_info.txt':\n" + readUserInfo);

// 6. Prompt the user to enter a directory path
Console.Write($"Enter a directory path (eg. {Directory.GetCurrentDirectory()}): ");
string directoryPath = Console.ReadLine();

// 7. List all files within the specified directory
if (Directory.Exists(directoryPath))
{
    string[] files = Directory.GetFiles(directoryPath);
    Console.WriteLine($"Files in {directoryPath}:");
    foreach (string file in files)
    {
        Console.WriteLine(Path.GetFileName(file));
    }
}
else
{
    Console.WriteLine("Directory does not exist.");
}

// 8. Prompt the user to input a string
Console.Write("Enter a string: ");
string userInput = Console.ReadLine();

// 9. Format the string to title case
TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
string titleCaseString = textInfo.ToTitleCase(userInput);
Console.WriteLine($"Title Case: {titleCaseString}");

// 10. Explicitly trigger garbage collection
GC.Collect();
Console.WriteLine("Garbage collection triggered.");