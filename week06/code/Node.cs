public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value == Data)
        {
            // Value already exists, do not insert
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // Check if the current node's value matches the search value
        if (value == Data)
        {
            // Found the value
            return true;
        }

        // Search in the subtree if value is less than current node's value 
        if (value < Data)
        {
            if (Left != null)
            {
                // Recurse into the left child
                return Left.Contains(value);
            }
            // Left child is null and value not found
            return false;
        }

        // Search in the right subtree if value is greater than current node's value
        if (Right != null)
        {
            // Recurse into the right child
            return Right.Contains(value);
        }
        // Right child is null and value not found
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // if the current node is null, the height is 0
        if (this == null)
        {
            // Base case
            return 0;
        }

        // Recursively calculate the height of the left and right subtrees
        int leftHeight = 0;
        if (Left != null)
        {
            // Get height of the left subtree
            leftHeight = Left.GetHeight();
        }

        int rightHeight = 0;
        if (Right != null)
        {
            // Get height of right subtree
            rightHeight = Right.GetHeight();
        }
        // Return the greater height plus one for the current node
        return Math.Max(leftHeight, rightHeight) + 1; // Replace this line with the correct return statement(s)
    }
}