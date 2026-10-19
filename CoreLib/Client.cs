namespace CoreLib
{
    public class Client
    {
        public string LastName { get; set; }   // Фамилия
        public string FirstName { get; set; }  // Имя
        public string MiddleName { get; set; } // Отчество

        public Client(string lastName, string firstName, string middleName)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }
    }
}