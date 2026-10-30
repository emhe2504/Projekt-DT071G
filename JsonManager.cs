
using System.Text.Json;

namespace ToDoList;

//
//class för JSON-hantering
public class JsonManager
{
    private string taskList = "tasks.json";
    private List<ToDo> tasks = new List<ToDo>();     //Ny lista för ToDo:s


    public List<ToDo> LoadFromJson()
    {
        //Om JSON-filen finns
        if (File.Exists(taskList))
        {
            //Läs in innehåll som sträng
            string jsonString = File.ReadAllText(taskList);

            //Deserialisera JSON-strängen till en lista med ToDo-objekt
            tasks = JsonSerializer.Deserialize<List<ToDo>>(jsonString)!;

        }

        return tasks;
    }

    //
    //Metod för att spara listan som JSON
    public void SaveToJson(List<ToDo> tasks)
    {
        var jsonString = JsonSerializer.Serialize(tasks);       //Serialisera listan till JSON-sträng
        File.WriteAllText(taskList, jsonString);                //Skriv JSON-strängen till filen
    }
}