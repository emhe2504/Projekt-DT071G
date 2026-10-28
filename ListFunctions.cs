
using System.Text.Json;

namespace ToDoList;

public class MakeList
{
    public string taskList = "tasks.json";
    public List<ToDo> tasks = new List<ToDo>();     //Ny lista för ToDo:s

    //Konstruktor
    public MakeList()
    {
        //Om filen finns
        if( File.Exists(taskList))
        {
            //lagra innehållet i variabeln
            string jsonString = File.ReadAllText(taskList);

            //deserialisera jsonString till lista med ToDo-objekt --> läggs i tasks
            tasks = JsonSerializer.Deserialize<List<ToDo>>(jsonString)!;

        }
    }
}