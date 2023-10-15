namespace TreeSharp.Models;

public class Node
{
    public int Id { get; set; }
    public ICollection<Node>? Children { get; set; }
}