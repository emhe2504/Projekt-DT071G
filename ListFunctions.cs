
namespace ToDoList;

//
//class för hantering av todos
public class ToDoManager
{
    private JsonManager jsonManager = new JsonManager();
    private List<ToDo> tasks;


    //
    //Konstruktor
    public ToDoManager()
    {
        tasks = jsonManager.LoadFromJson();
    }


    //
    //Metod för att lägga till Todo
    public void AddToDo(string task, int priority, bool done)
    {
        ToDo newTodo = new ToDo();
        newTodo.Task = task;                //värdet i task
        newTodo.Priority = priority;        //värdet i priority
        newTodo.Done = done;                //värdet i done
        tasks.Add(newTodo);                 //lägg till i tasks
        jsonManager.SaveToJson(tasks);
    }


     //
    //Metod för att ändra Todo
    public void UpdateToDo(int index,  bool done)
    {
        tasks[index].Done = done;
        jsonManager.SaveToJson(tasks);
    }

    //
    //Metod för att ta bort Todo
    public void DeleteToDo(int index)
    {
        tasks.RemoveAt(index);          //ta bort utifrån index
        jsonManager.SaveToJson(tasks);
    }


    //
    //Metod för att hämta alla todos
    public List<ToDo> GetToDos()
    {
        return tasks;
    }
}