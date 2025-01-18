using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: add a new item with its priority: Read (3) and add it to the back of the queue
    // Expected Result: the last item in the queue is Read with a priority of 3
    // Defect(s) Found: No defect found in the Enqueue method but there was difficulty in getting
    //                  the last item of the queue because the PriorityQueue collection is not iterable. 
    //                  To get around this, the queue was converted into a string and then into a list that is iterable. 
    public void TestPriorityQueue_1()
    {
        var Bread = new PriorityItem("Bread", 5); //added test case
        var Br = new PriorityItem("Br", 2); //added test case
        var Read = new PriorityItem("Read", 3); //added test case
        PriorityItem expectedResult = Bread; 

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(Bread.Value, Bread.Priority);
        priorityQueue.Enqueue(Br.Value, Br.Priority);
        priorityQueue.Enqueue(Read.Value, Read.Priority);
        // var length = priorityQueue.CountItems();
        var stringQueue = priorityQueue.ToString();
        stringQueue = stringQueue.Substring(1, stringQueue.Length - 2);
        string[] stringList = stringQueue.Split(",");
        string lastItem = stringList.Last();
        lastItem = lastItem.Trim();
        Debug.WriteLine(lastItem);
        Debug.WriteLine(Read.ToString());
        
        Assert.AreEqual(Read.ToString(), lastItem);
        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: dequeue an item from the queue, it should be the item with the highest priority
    // Expected Result: Br
    // Defect(s) Found: no defect found, the test past showing that the method is able to dequeue the highest priority item
    //                no necessary fixes.
    public void TestPriorityQueue_2()
    {
        var Bread = new PriorityItem("Bread", 5); //added test case
        var Br = new PriorityItem("Br", 8); //added test case
        var Read = new PriorityItem("Read", 3); //added test case
        PriorityItem expectedResult = Bread; 

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(Bread.Value, Bread.Priority);
        priorityQueue.Enqueue(Br.Value, Br.Priority);
        priorityQueue.Enqueue(Read.Value, Read.Priority);
        var dequeuedItem = priorityQueue.Dequeue();
        Debug.WriteLine(dequeuedItem);
        Assert.AreEqual("Br", dequeuedItem);
        // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
     [TestMethod]
    // Scenario: a case where two items have the same priority, the method should bring the first item of the two in the list.
    // Expected Result: Br
    // Defect(s) Found: Expected:<Bread>. Actual:<Br>.
    //                the problem is caused by the fact that the index iterates from 1 instead of 0
    //                another problem is that the loop was ending at index < count- 1 instead of < count 
    //                another problem is that the loop was bringing the latter item in case of two equal priorities
    public void TestPriorityQueue_3()
    {
        var Bread = new PriorityItem("Bread", 8); //added test case
        var Br = new PriorityItem("Br", 8); //added test case
        var Read = new PriorityItem("Read", 8); //added test case
        PriorityItem expectedResult = Bread; 

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(Bread.Value, Bread.Priority);
        priorityQueue.Enqueue(Br.Value, Br.Priority);
        priorityQueue.Enqueue(Read.Value, Read.Priority);
        var dequeuedItem = priorityQueue.Dequeue();
        Debug.WriteLine(dequeuedItem);
        
        Assert.AreEqual("Bread", dequeuedItem);
    }

     [TestMethod]
    // Scenario: run the code with an empty queue. 
    // Expected Result: throws exception with message "The queue is empty."
    // Defect(s) Found: none, the code correctly throws the exception and the test was passed
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        
        Assert.AreEqual("The queue is empty.", Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue()).Message);
        // Assert.Fail("Implement the test case and then remove this.");
    }
}