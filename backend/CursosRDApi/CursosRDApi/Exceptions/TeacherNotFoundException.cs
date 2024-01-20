namespace CursosRDApi.Exceptions
{
    [Serializable]
    public class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException() { }
        public TeacherNotFoundException(string message) : base(message)
        {
           

        }



    }
}
