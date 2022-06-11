namespace WordUnscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.FirstName = "diego";
            person.LastName = "canizales";

            ChangeName(person);

            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);
        }

        static void ChangeName(Person personToChange)
        {
            personToChange.FirstName = "Jane";
            personToChange.LastName = "Doe";
        }
    }

    struct Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}