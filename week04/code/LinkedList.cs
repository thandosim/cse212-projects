using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        //create a new node
        Node newNode = new(value);
        //check if the list is empty
        if (_tail is null)
        {
            //point both head and tail to the new node
            _head = newNode;
            _tail = newNode;
        }
        // if the list is not empty, 
        else
        {
            // connect the new node to the previous tail
            newNode.Prev = _tail;
            //connect the previous tail to the new node
            _tail.Next = newNode;
            //update the tail to point to the new node
            _tail = newNode;
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        //if the list is emmpty or has one item
        if (_head==_tail)
        {
            //set head and tail to null
            _head=null;
            _tail=null;
        }
        //if the list is longer than 1 item
        else if (_tail is not null)
        {
            //disconnect the second-to-last node from the tail
            _tail.Prev!.Next = null;
            //point the tail to the second-to-last node
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        // start at the head of the linked list
        Node? curr = _head;
        //if the current node is not null
        while (curr is not null)
        {
            // if the current node matches the value we are looking for
            if (curr.Data == value)
            {
                // if the current node is the head
                if (curr==_head)
                {
                    //call the removeHead function
                    RemoveHead();
                }
                // if its the tail
                else if (curr==_tail)
                {
                    // call the removeTail function
                    RemoveTail();
                }
                //for any other value
                else
                {
                    //connect the node before current, to the node after current
                    curr.Prev.Next = curr.Next;
                    //connect the node after current to the node before current
                    curr.Next.Prev = curr.Prev;
                    // this leaves the current node disconnected from any other nodes, 
                    //essentially deleting it because it cant be found
                }
                // exit the function after deleting
                return;
            }  
            //got to the next nde to check it
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        // start at the head of the linked list
        Node? curr = _head;
        //if the current node is not null
        while (curr is not null)
        {
            // if the current node matches the value we are looking for
            if (curr.Data == oldValue)
            {
                //Replace the data in the old node with the new data 
                curr.Data = newValue;
            }  
            //got to the next node to check it
            curr = curr.Next;
        }

    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        // start at the tail
        var curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
        // yield return 0; // replace this line with the correct yield return statement(s)
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}