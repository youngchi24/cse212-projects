using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: The item with the highest priority is removed first.
    // Defect(s) Found: The original implementation skips the last item when
    // searching for the highest priority because of an incorrect loop condition.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Banana", 3);
        priorityQueue.Enqueue("Orange", 5);

        Assert.AreEqual("Orange", priorityQueue.Dequeue());
        Assert.AreEqual("Banana", priorityQueue.Dequeue());
        Assert.AreEqual("Apple", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with equal highest priorities.
    // Expected Result: Items with equal priorities are removed in FIFO order.
    // Defect(s) Found: The original implementation uses >= instead of >,
    // causing later items with equal priorities to be selected first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three items and dequeue them one after another.
    // Expected Result: Each item is removed after being dequeued.
    // Defect(s) Found: The original implementation returns an item without
    // removing it from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue an item from an empty queue.
    // Expected Result: InvalidOperationException with the message
    // "The queue is empty."
    // Defect(s) Found: No defects found. The original implementation
    // correctly handles an empty queue.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Add three items to the queue.
    // Expected Result: Items are added to the back in FIFO order.
    // Defect(s) Found: No defects found. The original Enqueue method
    // correctly adds items to the back of the queue.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual(
            "[First (Pri:1), Second (Pri:2), Third (Pri:3)]",
            priorityQueue.ToString()
        );
    }
}