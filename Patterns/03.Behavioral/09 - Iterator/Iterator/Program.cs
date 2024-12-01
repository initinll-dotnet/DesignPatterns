using Iterator;

Console.Title = "Iterator";

// create the collection
PeopleCollection people =
[
    new Person("Kevin Dockx", "Belgium"),
    new Person("Gill Cleeren", "Belgium"),
    new Person("Roland Guijt", "The Netherlands"),
    new Person("Thomas Claudius Huber", "Germany"),
];

// create the iterator
var peopleIterator = people.CreateIterator();

// use the iterator to run through the people
// in the collection; they should come out 
// in alphabetical order
for (Person person = peopleIterator.First();!peopleIterator.IsDone;person = peopleIterator.Next())
{
    Console.WriteLine(person?.Name);
}

Console.ReadKey();