
using System.Text.Json;

namespace ToDoList;

public class ToDoManager //class för hantering av todos
{
    public string taskList = "tasks.json";
    public List<ToDo> tasks = new List<ToDo>();     //Ny lista för ToDo:s

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

    public void SaveToJson()        //Metod för att spara listan som JSON
    {
        var jsonString = JsonSerializer.Serialize(tasks);       //Serialisera listan till JSON-sträng
        File.WriteAllText(taskList, jsonString);                //Skriv JSON-strängen till filen
    }
}