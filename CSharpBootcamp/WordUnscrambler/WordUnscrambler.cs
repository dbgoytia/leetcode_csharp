namespace WordUnscrambler
{
    class Program
    {
        static void Main(string[] args)
        { 
            Person person = null;

            Person newPerson = person ?? new Person("Default", "Person");

            Console.WriteLine(newPerson.FirstName);
            Console.WriteLine(newPerson.LastName);

        }
    }

    class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}