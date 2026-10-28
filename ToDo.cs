
namespace ToDoList;

//Public class ToDo
public class ToDo
{
    public string? Task { get; set; }   //string - uppgiften

    public int? Priority { get; set; }  //int - prioritet

    public bool Done { get; set; }      //bool - klar/inte klar
}