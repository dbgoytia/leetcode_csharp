Word Unscrambler
=================


This is a nice opportunity to get back on track. The goal of this exercises
is to learn a little bit about data structures, along with simple flow diagrams
and picking up requirements for a very simple application.

Topics covered:

* Lists
* Arrays
* Array.Sort()
* Reference vs Value types
* Classes vs Structs
* Ref and Out keywords


## Lists

Lists dymamically grow as you add elements to it. However, this is a more
complex datastructure when loaded in memory. This is very useful when you
do not want to worry about the underlying memory allocation of the elements to
be stored.


```
// List - this have dynamic capacity, but come with some gotchas
List<string> myList = new List<string>();
myList.Add("diego");
myList.Add("guillian");
```


## Arrays

With Arrays, you basically need to instanciate them with a given initial capacity.
In order to grow them, you have to copy them into an array of larger memory allocation
yourself. This comes with some benefits though, the underlying datastructure
used to store the data is smaller, and faster, but less flexible than Lists.

```
// Array - you have to give it an initial capacity
int[] myArray = new int[10];
```


## Arrays.Sort()

There are already a number of sorting algorithms already implemented for arrays
that you can use out of the box.


## Reference vs Value Types


### Passing by Value 

By value it means that we're literally creating a new copy of the variable in our
methods, and returning that value into the variable in which we want to store it
in.


```

// Total of two "a" variables stored in memory, one for the Main method,
// and one for the ChangeNumber "a" variable.

static void Main(string[] args)
{
    int a = 10;
    a = ChangeNumber(a);
    Console.WriteLine(a);
}

static int ChangeNumber(int a)
{
    a = 90;
    return a;
}
```


### Getting confused

One intereseting example, when you're dealing with custom classes, apparently
you always pass by reference in C#.

```
class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person.FirstName = "Diego";
        person.LastName = "Canizales";

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

class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

>> Jane
>> Doe

```


Formal definitions:

On a the Call Stack inside C#, whenever we're putting elements, we're actually
pushing them down. We're putting more elements on top of it, take for example our
first program:

* You can see that our next calls are added on top of the previous calls.
* Adding things to the Stack is called **pushing**, removing them, is called **popping**.
* The heap is unsused with Value types.

```

    Call Stack                      Heap
 
|    ___________    |       |                       |
|   | Change    |   |       |                       |
|   | Number    |   |       |                       |
|   | a = 90    |   |       |                       |
|    -----------    |       |                       |
|                   |       |                       |
|    ___________    |       |                       |
|   | Main      |   |       |                       |
|   | a = 10    |   |       |                       |
|    -----------    |       |                       |
 -------------------         -----------------------


```

On the second example, when we passed a Reference type, you can see that
they are both pointing to the same memory region, so they can modify that value
without having to create a new copy. In other langauges, this can be a little bit
more intelligent and you can usually choose either to pass by value or pass by Reference.
Hence, Classes are **Reference types**.

```

    Call Stack                      Heap
 
|    _______________ |       |                       |
|   | Change        ||       |                       |
|   | Name          ||       |  ____________________ |                     
|   | personToChange|| -----*|  | Person             ||    
|    --------------- |     / | | FristName: Diego   ||              
|                    |    /  | | LastName: Canizales||                 
|    ___________     |   /   |   ------------------- |                    
|   | Main      |    |  /    |                       |
|   | person    |    | /     |                       |
|    -----------     |       |                       |
 -------------------         -----------------------


```


## Classes vs Structs

Now, another fun example is to introduce Structs. We now know that classes are
Reference types. Interestingly, **Structs are Value types**. Take the following
example:

```
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

>> diego
>> canizales
```

Structs are:
* A lot more basic than classes, for example, they can't have inheritance.
* They are Value types.
* There is one work around that is actually preferred by other languages, like golang,
you're able to implement various **interfaces** on a struct, and this is safe to do.
    * Refer to: https://stackoverflow.com/questions/63671/is-it-safe-for-structs-to-implement-interfaces



## Out vs Reference

Another option we have to force value types to behave as reference types is to use
the **ref** or **out** keywords. For example:

```
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        ChangeNumber(ref a);
        Console.WriteLine(a);
    }

    static void ChangeNumber(ref int a)
    {
        a = 90;
    }
}

>> 90
```

```
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        ChangeNumber(out a);
        Console.WriteLine(a);
    }

    static void ChangeNumber(out int a)
    {
        a = 90;
    }
}

>> 90
```


So the difference is basically:
* With ref, the parameter that we're trying to use has to be initialized.
* With out, the parameter can be unilitialized, it doesn't care about that.

See: [ref vs out keywords](https://www.c-sharpcorner.com/UploadFile/ff2f08/ref-vs-out-keywords-in-C-Sharp/)



## Null vs Null Coalescing

One other thing we need to go through before building actuall applications is
handling of nulls, take the following error:


```
class Program
{
    static void Main(string[] args)
    {
        Person newPerson = new Person("John", "Doe");

        Console.WriteLine(newPerson.FirstName);
        Console.WriteLine(newPerson.LastName);


        Person nullPerson = null;
        Console.WriteLine(nullPerson.FirstName);
        Console.WriteLine(nullPerson.LastName);

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

>> System.NullReferenceException has been thrown
```


As you can see this is not a compile time error since the complier didn't
threw this before actually running the code, but when we were actually running
it, it appeared. From the instanciated null object we're trying to get a value
that simply doesn't exist, we can't use that property from that class.

This is where null coalescing comes into play. It is simply a check for null
values in a program, and it's represented through **??**.

Example:

```
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
```

This will efectively create a new default object, in this case a default person,
in the case that the Object is pointing to null.








