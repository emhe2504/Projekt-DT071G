
using System.Text.Json;

namespace ToDoList;

//
//class för hantering av todos
public class ToDoManager
{
    public string taskList = "tasks.json";
    public List<ToDo> tasks = new List<ToDo>();     //Ny lista för ToDo:s


    //
    //Konstruktor
    public ToDoManager()
    {
        //Om JSON-filen finns
        if (File.Exists(taskList))
        {
            //Läs in innehåll som sträng
            string jsonString = File.ReadAllText(taskList);

            //Deserialisera JSON-strängen till en lista med ToDo-objekt
            tasks = JsonSerializer.Deserialize<List<ToDo>>(jsonString)!;

        }
    }


    //
    ////Metod för att lägga till Todo
    public void AddToDo(string task, int priority, bool done)
    {
        ToDo newTodo = new ToDo();
        newTodo.Task = task;
        newTodo.Priority = priority;
        newTodo.Done = done;
        tasks.Add(newTodo);
        SaveToJson();
    }


    //
    ////Metod för att spara listan som JSON
    public void SaveToJson()
    {
        var jsonString = JsonSerializer.Serialize(tasks);       //Serialisera listan till JSON-sträng
        File.WriteAllText(taskList, jsonString);                //Skriv JSON-strängen till filen
    }
}