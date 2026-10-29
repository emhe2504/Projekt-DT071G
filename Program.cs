
/*
* Filnamn: Program.cs
* Författare: Emma Heikkinen
* Datum: 2026-11-01
* Kurs: Programmering i C#.NET DT071G
* 
* Beskrivning:
* En konsolappplikation i form av en Att-göra lista där användaren
kan lägga till, bocka av och ta bort uppgifter.
*/

using ToDoList;

//För att visa å, ä, ö
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.Unicode;

//Nytt ToDo-objekt
ToDoManager newToDo = new ToDoManager();

//Lista för startsidan
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
    Console.WriteLine("4. Se din list-statistik");
    Console.WriteLine("5. Avsluta.");
    Console.WriteLine();

    //Vad vill användaren göra?
    Console.Write("Vad önskar du göra? ");
    Console.ResetColor();
    string? choice = Console.ReadLine();

    if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
    {
        Console.WriteLine("Ange nummer som finns i menyn.");        //felmeddelande
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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Dags att ange en ny uppgift!");

            //Först false
            Console.WriteLine("Uppgiften markeras automatiskt som (Ej färdig)");
            Console.WriteLine();
            Console.ResetColor();

            //Uppgift
            Console.Write("Vad har du för uppgift?: ");
            string? addedTask = Console.ReadLine();

            //Till "startsidan" om tomt fält
            if (string.IsNullOrWhiteSpace(addedTask))
            {
                Console.WriteLine("Du angav inte någon uppgift.");       //felmeddelande
                Console.WriteLine("Tryck Enter för att återgå till meny.");
                Console.ReadLine();
                continue;
            }

            //Prioritet
            Console.Write("Vilken prioritet (1-3)?: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int addedPriority) ||
                addedPriority < 1 || addedPriority > 3)
            {
                Console.WriteLine("Ogiltig prioritet. Prioritet 1 används.");
                Console.WriteLine("Tryck Enter för att fortsätta.");
                Console.ReadLine();
                addedPriority = 1;
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
                    Console.WriteLine("Tryck Enter för att återgå till meny.");
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

                    Console.WriteLine("Statusen har uppdaterats!");
                    Console.WriteLine("Tryck Enter för att fortsätta.");
                    Console.ReadLine();
                }
                else if (addedStatus == "nej")
                {
                    currentTodo.Done = false;
                    newToDo.SaveToJson();           //spara ändringar

                    Console.WriteLine("Statusen har uppdaterats!");
                    Console.WriteLine("Tryck Enter för att fortsätta.");
                    Console.ReadLine();
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

            //Rensa konsollen, men visa uppgifter som finns att radera
            Console.Clear();

            int ind = 1;
            foreach (ToDo todo in newToDo.GetToDos())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine(" [" + ind++ + "] " + todo.Task + " ");
                Console.WriteLine();
                Console.ResetColor();
            }

            Console.Write("Ange vilken uppgift du vill radera: ");
            string? indexAnswer = Console.ReadLine();

            if (string.IsNullOrEmpty(indexAnswer))   //Tillbaka till start om inget anges
            {
                continue;
            }

            //Prova att ta bort inlägg
            try
            {
                int fixedIndex = Convert.ToInt32(indexAnswer) - 1;      //-1 för rätt index
                newToDo.DeleteToDo(Convert.ToInt32(fixedIndex));
            }
            catch (Exception)
            {
                Console.WriteLine("Fel uppstod, prova igen senare. Tryck enter.");  //Om något blir fel
                Console.ReadKey();
            }
            break;


        //
        //Se list-statistik
        case "4":

            Console.Clear();

            string Trophy = @"
               ============== 
             / ============== \
            | /              \ |
            \|                |/
             \      100%      /
              \              /
               \            /
                \          /
                  ========
                    |  |   
                    |  |
                    |  |
                  ========
                ===========";

            ToDoStatistics statistics = new ToDoStatistics();
            var allResults = statistics.TodoPercent();          //För att nå vad den returnerar

            //Omvandla till int
            int precComp = (int)allResults.precentComplete;
            int precInComp = (int)allResults.percentInComplete;

            //Om det inte finns några uppgifter
            if (allResults.TotalTodoCount == 0)
            {
                Console.WriteLine("Det finns inga uppgifter i listan att ange statistik för.");
                Console.WriteLine("Tryck Enter för gå tillbaka till menyn och lägga till nya uppgifter.");
                Console.ReadLine();
                continue;
            }

            //Skriva ut all statistik
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("> Du har totalt: " + allResults.TotalTodoCount + " uppifter på din lista.");
            Console.WriteLine("> Du har markerat " + allResults.complete + " som Färdig.");
            Console.WriteLine("> Du har " + allResults.inComplete + " uppgifter markerade som Ej färdig");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Det betyder att " + precComp + "% av uppgifterna är klara.");
            Console.WriteLine("Samt att du har " + precInComp + "% av uppgifterna kvar att göra.");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            //Ge feedback beroende på procent avklarade uppgifter
            if (allResults.precentComplete == 100)
            {
                Console.WriteLine("Grattis! Du har klarat av 100% av dina uppgfifter. Bra jobbat.");
                Console.WriteLine("Din pokal:");
                Console.WriteLine();
                Console.WriteLine(Trophy);
            }
            else if (allResults.precentComplete >= 75)
            {
                Console.WriteLine("Du närmar dig målet på 100% avklarade uppgifter, snart där!");
            }
            else if (allResults.precentComplete < 75)
            {
                Console.WriteLine("Du har en bit kvar till 100%, du klarar det här!");
            }

            Console.WriteLine();
            Console.WriteLine("Tryck Enter för att återgå till menyn.");
            Console.ReadLine();

            break;

        //
        //Avsluta programmet direkt
        case "5":
            Environment.Exit(0);
            break;
    }
}