namespace TreeSharp.Models;

public class Node
{
    public int ID { get; set; }
    public ICollection<Node>? Children { get; set; }
}