// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Node tree = new Node();
tree.left=new Node(); 
tree.right=new Node();

tree.left.left=new Node();
tree.left.right=new Node();

TreeValidator.ValidateBalance(tree, 0);

class TreeValidator
{
    public static int ValidateBalance(Node node, int depth)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            int rDeepth = ValidateBalance(node.left, depth);
            int lDeepth = ValidateBalance(node.right, depth);
            if (Math.Abs(rDeepth - lDeepth) <= 1)
            {
                int currentDeepth = Math.Max(rDeepth, lDeepth);
                return currentDeepth + 1;
            }
            else
            {
                throw new Exception("Not balanced");
            }
        }

    }
}

class Node
{
    public Node left;
    public Node right;
}
