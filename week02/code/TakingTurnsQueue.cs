/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added
/// to the back of the queue. When GetNextPerson is called, the next person
/// is returned and placed back into the queue if they still have turns.
/// A turns value of 0 or less means infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns: keep the person in the queue.
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Decrease remaining turns and re-enqueue.
            person.Turns--;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}