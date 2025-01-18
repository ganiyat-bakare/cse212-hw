using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.


[TestClass]  
public class PriorityQueueTests  
{  
    [TestMethod]  
    // Scenario: Add items with varying priorities and dequeue them.  
    // Expected Result: The item with the highest priority should be returned first.  
    // Defect(s) Found: Need to check that the order of removal matches the priority.  
    public void TestPriorityQueue_1()  
    {  
        var priorityQueue = new PriorityQueue();  
        priorityQueue.Enqueue("A", 1);  
        priorityQueue.Enqueue("B", 3);  
        priorityQueue.Enqueue("C", 2);  

        Assert.AreEqual("B", priorityQueue.Dequeue(), "Expected highest priority item.");  
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Expected next highest priority item.");  
        Assert.AreEqual("A", priorityQueue.Dequeue(), "Expected last item in the queue.");  
    }  

    [TestMethod]  
    // Scenario: Add multiple items with the same priority.  
    // Expected Result: The first item added with the same priority should be dequeued first.  
    // Defect(s) Found: Test for FIFO behavior when priorities are the same.  
    public void TestPriorityQueue_2()  
    {  
        var priorityQueue = new PriorityQueue();  
        priorityQueue.Enqueue("A", 2);  
        priorityQueue.Enqueue("B", 2);  
        priorityQueue.Enqueue("C", 3);  

        Assert.AreEqual("C", priorityQueue.Dequeue(), "Expected highest priority item.");  
        Assert.AreEqual("A", priorityQueue.Dequeue(), "Expected first added item with the same priority.");  
        Assert.AreEqual("B", priorityQueue.Dequeue(), "Expected next item with the same priority.");  
    }  

    [TestMethod]  
    // Scenario: Attempt to dequeue from an empty queue.  
    // Expected Result: An exception should be thrown indicating the queue is empty.  
    // Defect(s) Found: Verify correct exception handling.  
    public void TestPriorityQueue_Empty()  
    {  
        var priorityQueue = new PriorityQueue();  
        
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "Expected exception for dequeuing from an empty queue.");  
    }  

    [TestMethod]  
    // Scenario: Add multiple items and ensure correct order regardless of addition order.  
    // Expected Result: Items should be dequeued in the order of their priority and adding them correctly.  
    public void TestPriorityQueue_MixedPriorities()  
    {  
        var priorityQueue = new PriorityQueue();  
        priorityQueue.Enqueue("A", 1);  
        priorityQueue.Enqueue("B", 5);  
        priorityQueue.Enqueue("C", 3);  
        priorityQueue.Enqueue("D", 4);  

        Assert.AreEqual("B", priorityQueue.Dequeue(), "Expected highest priority item.");  
        Assert.AreEqual("D", priorityQueue.Dequeue(), "Expected next highest priority item.");  
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Expected next highest priority item.");  
        Assert.AreEqual("A", priorityQueue.Dequeue(), "Expected last item.");  
    }  
}