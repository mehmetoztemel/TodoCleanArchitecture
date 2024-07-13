namespace TodoCleanArchitecture.Application.Features.Todos.CreateTodo
{
    public class DublicateRecordWorkException : Exception
    {
        public DublicateRecordWorkException() : base("This record alread exist")
        {

        }
    }
}