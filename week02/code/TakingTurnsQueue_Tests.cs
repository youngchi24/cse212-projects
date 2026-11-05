using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 1 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with people who have a finite number of turns.
    // Add Bob (2 turns), Tim (5 turns), and Sue (3 turns).
    // Expected Result: Each person should take turns until their remaining
    // turns reach zero. People should be removed after completing their turns.
    // Defect(s) Found: No defects found. The queue correctly decreases the
    // remaining turns and removes people when they have completed all their turns.
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var queue = new TakingTurnsQueue();

        queue.AddPerson("Bob", 2);
        queue.AddPerson("Tim", 5);
        queue.AddPerson("Sue", 3);

        var expectedResult = new[]
        {
            "Bob", "Tim", "Sue", "Bob", "Tim",
            "Sue", "Tim", "Sue", "Tim", "Tim"
        };

        foreach (var expected in expectedResult)
        {
            var person = queue.GetNextPerson();
            Assert.AreEqual(expected, person.Name);
        }
    }

    [TestMethod]
    // Scenario: Add a new person to the queue while other people are still
    // taking their turns.
    // Expected Result: The new person should join the back of the queue
    // without changing the existing order.
    // Defect(s) Found: No defects found. The queue correctly allows a new person
    // to be added while maintaining the existing queue order.
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var queue = new TakingTurnsQueue();

        queue.AddPerson("Bob", 2);
        queue.AddPerson("Tim", 5);
        queue.AddPerson("Sue", 3);

        var expectedResult = new[]
        {
            "Bob", "Tim", "Sue", "Bob", "Tim",
            "Sue", "Tim", "George", "Sue", "Tim",
            "George", "Tim", "George"
        };

        var i = 0;

        foreach (var expected in expectedResult)
        {
            if (i == 5)
            {
                queue.AddPerson("George", 3);
            }

            var person = queue.GetNextPerson();
            Assert.AreEqual(expected, person.Name);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add a person with zero turns to the queue.
    // Expected Result: A person with zero turns should remain in the queue
    // forever, and their turns should remain zero.
    // Defect(s) Found: The original implementation fails to re-enqueue people
    // whose turns are zero. People with zero turns should remain in the queue forever.
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var queue = new TakingTurnsQueue();

        queue.AddPerson("Bob", 2);
        queue.AddPerson("Tim", 0);
        queue.AddPerson("Sue", 3);

        var expectedResult = new[]
        {
            "Bob", "Tim", "Sue", "Bob", "Tim",
            "Sue", "Tim", "Sue", "Tim", "Tim"
        };

        foreach (var expected in expectedResult)
        {
            var person = queue.GetNextPerson();
            Assert.AreEqual(expected, person.Name);

            if (person.Name == "Tim")
            {
                Assert.AreEqual(0, person.Turns);
            }
        }
    }

    [TestMethod]
    // Scenario: Add a person with negative turns to the queue.
    // Expected Result: A person with negative turns should remain in the queue
    // forever, and their turns should remain unchanged.
    // Defect(s) Found: The original implementation fails to re-enqueue people
    // whose turns are negative. Negative turns should also represent infinite turns.
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        var queue = new TakingTurnsQueue();

        queue.AddPerson("Tim", -3);
        queue.AddPerson("Sue", 3);

        var expectedResult = new[]
        {
            "Tim", "Sue", "Tim", "Sue", "Tim",
            "Sue", "Tim", "Tim", "Tim", "Tim"
        };

        foreach (var expected in expectedResult)
        {
            var person = queue.GetNextPerson();
            Assert.AreEqual(expected, person.Name);

            if (person.Name == "Tim")
            {
                Assert.AreEqual(-3, person.Turns);
            }
        }
    }

    [TestMethod]
    // Scenario: Attempt to get the next person when the queue is empty.
    // Expected Result: The queue should throw an InvalidOperationException
    // with the expected message.
    // Defect(s) Found: No defects found. The implementation correctly throws an
    // InvalidOperationException with the expected message when the queue is empty.
    public void TestTakingTurnsQueue_Empty()
    {
        var queue = new TakingTurnsQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => queue.GetNextPerson()
        );

        Assert.AreEqual("No one in the queue.", exception.Message);
    }
}