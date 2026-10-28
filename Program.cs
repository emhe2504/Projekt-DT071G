
/*
* Filnamn: Program.cs
* Författare: Emma Heikkinen
* Datum: 2026-11-01
* Kurs: Programmering i C#.NET DT071G
* 
* Beskrivning:
* En konsolappplikation i form av en Att-göra lista där användaren
kan lägga till, ändra, bocka av och ta bort uppgifter.
*/


using ToDoList;

//Nytt ToDo-objekt
ToDo newToDo = new ToDo();

//Lista gör startsidan
    string list = @"
        _______________
       |   Att göra:   |
       |               |
       | * ~~~~~~~~~~  |
       | * ~~~~~~~~~~  |
       | * ~~~~~~~~~~  |
       | * ~~~~~~~~~~  |
       | * ~~~~~~~~~~  |
       |               |
       |_______________|
    ";

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta; //Ändra textfärg

    //Att-göra listans startsida

    Console.WriteLine(list);
    Console.WriteLine();
    Console.WriteLine(" Dags att utföra uppgifter!");
    Console.WriteLine();
    Console.WriteLine(" Vad du har att göra: ");

    Console.ResetColor();
    Console.ReadLine();
}