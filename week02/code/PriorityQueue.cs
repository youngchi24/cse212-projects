public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the back of the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the item with the highest priority.
    /// If priorities are equal, the first item is removed.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var highPriorityIndex = 0;

        for (int index = 1; index < _queue.Count; index++)
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        var value = _queue[highPriorityIndex].Value;

        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    // DO NOT MODIFY THIS METHOD
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THIS METHOD
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}