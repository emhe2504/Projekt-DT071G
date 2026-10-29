
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
ToDoManager newToDo = new ToDoManager();

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
    Console.ForegroundColor = ConsoleColor.Yellow; //Ändra textfärg

    //Att-göra listans startsida

    Console.WriteLine(list);
    Console.WriteLine();
    Console.WriteLine("   Dags att utföra uppgifter!");
    Console.WriteLine();
    Console.WriteLine(" -~-~-~-~-~-~-~-~-~-~-~-~-~-~-~- ");
    Console.WriteLine();
    Console.WriteLine(" Vad du har att göra: ");
    Console.WriteLine();

    Console.ResetColor();


    string status;

    int index = 1;
    foreach (ToDo todo in newToDo.GetToDos())
    {

        if (todo.Done == false)
        {
            status = "Ej färdig";

            Console.WriteLine(" [" + index++ + "] " + todo.Task + " ");
            Console.WriteLine(" Prioritet: " + todo.Priority);
            Console.WriteLine(" Status: " + status);
            Console.WriteLine();
        }
        else
        {
            status = "Färdig";

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" [" + index++ + "] " + todo.Task + " ");
            Console.WriteLine(" Prioritet: " + todo.Priority);
            Console.WriteLine(" Status: " + status);
            Console.WriteLine();
            Console.ResetColor();
        }
    }

    //Meny
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine();
    Console.WriteLine("1. Lägga till uppgift.");
    Console.WriteLine("2. Markera uppgift som färdig");
    Console.WriteLine("3. Ta bort uppgift");
    Console.WriteLine("4. Avsluta.");
    Console.WriteLine();

    //Vad vill användaren göra?
    Console.Write("Vad önskar du göra? ");
    Console.ResetColor();
    string? choice = Console.ReadLine();

    if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
    {
        continue;
    }

    switch (choice)
    {
        //Addera todo
        case "1":
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Uppgift måste anges!");

            //Först false
            Console.WriteLine("Uppgiften markeras automatiskt som (Ej färdig)");
            Console.WriteLine();

            //Uppgift
            Console.Write("Vad har du för uppgift?: ");
            string? addedTask = Console.ReadLine();

            //Prioritet
            Console.Write("Vilken prioritet (1-3)?: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int addedPriority) ||
                addedPriority < 1 || addedPriority > 3)
            {
                addedPriority = 1;
            }

            //Till "startsidan" om tomt fält
            if (string.IsNullOrWhiteSpace(addedTask))
            {
                continue;
            }

            newToDo.AddToDo(addedTask, addedPriority, false);      //Uppgift läggs till
            break;

        case "2":
            Console.Clear();
            break;

        case "3":
            Console.Clear();
            break;

        case "4":
            Environment.Exit(0);        //Avsluta programmet direkt
            break;
    }
}