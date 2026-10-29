
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
    Console.WriteLine("1. Lägga till uppgift");
    Console.WriteLine("2. Uppdatera status");
    Console.WriteLine("3. Ta bort uppgift");
    Console.WriteLine("4. Avsluta.");
    Console.WriteLine();

    //Vad vill användaren göra?
    Console.Write("Vad önskar du göra? ");
    Console.ResetColor();
    string? choice = Console.ReadLine();

    if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
    {
        Console.WriteLine("Ange nummer som finns i menyn.");
        Console.WriteLine("Tryck Enter för att fortsätta.");
        Console.ReadLine();
        continue;
    }

    switch (choice)
    {
        //
        //Addera todo
        case "1":
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Uppgift måste anges för att spara!");

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



        //
        //Uppdatera status
        case "2":

            Console.Write("Ange nummer på uppgift: ");
            string? numberInput = Console.ReadLine();
            if (int.TryParse(numberInput, out int addedNumber))     //Kontroll om parse lyckas
            {
                int indexToChange = addedNumber - 1;                //-1 för korrekt index

                if (indexToChange < 0 || indexToChange >= newToDo.tasks.Count)
                {
                    Console.WriteLine("Det finns ingen uppgift med det numret.");       //felmeddelande
                    Console.WriteLine("Tryck Enter för att fortsätta.");
                    Console.ReadLine();
                    continue;
                }

                //Beroende på ja eller nej, ändra done till true/false vid index
                Console.Write("Är uppgiften utförd? (ja/nej) ");
                string? addedStatus = Console.ReadLine()?.ToLower();

                var currentTodo = newToDo.tasks[indexToChange];

                if (addedStatus == "ja")
                {
                    currentTodo.Done = true;
                    newToDo.SaveToJson();           //spara ändringar
                }
                else if (addedStatus == "nej")
                {
                    currentTodo.Done = false;
                    newToDo.SaveToJson();           //spara ändringar
                }
                else
                {
                    Console.WriteLine("Svara med ja eller nej.");           //felmeddelande
                    Console.WriteLine("Tryck Enter för att fortsätta.");
                    Console.ReadLine();
                }
                continue;
            }
            else
            {
                Console.WriteLine("Ange ett giltigt uppgiftsnummer.");     //felmeddelande
                Console.WriteLine("Tryck Enter för att fortsätta.");
                Console.ReadLine();
            }

            break;


        //
        //Radera todo
        case "3":
            Console.Clear();
            break;


        //
        //Avsluta programmet direkt
        case "4":
            Environment.Exit(0);
            break;
    }
}