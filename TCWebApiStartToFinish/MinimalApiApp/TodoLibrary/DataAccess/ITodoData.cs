using TodoLibrary.Models;

namespace TodoLibrary.DataAccess;
public interface ITodoData
{
    Task CompleteTodo(int assginedTo, int todoId);
    Task<TodoModel?> Create(int assginedTo, string task);
    Task Delete(int assginedTo, int todoId);
    Task<List<TodoModel>> GetAllAssigned(int assginedTo);
    Task<TodoModel?> GetOneAssigned(int assginedTo, int todoId);
    Task UpdateTask(int assginedTo, int todoId, string task);
}