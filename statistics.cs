

namespace ToDoList;

//
//class för todo-statistik
public class ToDoStatistics
{
    //
    //Metod för att beräkna procent på todos
    public (int TotalTodoCount, int complete, int inComplete, double precentComplete, double percentInComplete) TodoPercent()
    {
        ToDoManager newToDo = new ToDoManager();

        int complete = 0;
        int inComplete = 0;

        foreach (ToDo todo in newToDo.GetToDos())
        {
            bool status = todo.Done;

            if (status == true)
            {
                complete++;
            }
            else if (status == false)
            {
                inComplete++;
            }
        }


        var list = newToDo.GetToDos();
        int TotalTodoCount = list.Count();

        if (TotalTodoCount == 0)
        {
            return (0, 0, 0, 0.0, 0.0);
        }

        double precentComplete = (double)complete / TotalTodoCount * 100;
        double percentInComplete = (double)inComplete / TotalTodoCount * 100;

        return (TotalTodoCount, complete, inComplete, precentComplete, percentInComplete);
    }
}