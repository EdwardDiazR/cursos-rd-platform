namespace CursosRDApi.Exceptions
{
    public class OutOfDateException:Exception
    {
        public OutOfDateException() { }

        public OutOfDateException(string message) : base(message)
        {

        }
    }
}
