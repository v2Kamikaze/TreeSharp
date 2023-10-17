using Microsoft.AspNetCore.Mvc;
using TreeSharp.Database;
using TreeSharp.Models;

namespace TreeSharp.Services;

public class TreeBuilderService
{
    private AppDbContext dbContext;

    public TreeBuilderService([FromServices] AppDbContext dbContext)
    {   
        this.dbContext = dbContext;

        /* Records = new List<Record>
        {
            new Record {
                Id = 1,
                Parent = 0,
            },

            new Record {
                Id = 2,
                Parent = 1,
            },

            new Record {
                Id = 4,
                Parent = 1,
            },

            new Record {
                Id = 3,
                Parent = 0,
            },

            new Record {
                Id = 6,
                Parent = 3,
            },

            new Record {
                Id = 5,
                Parent = 0,
            },
           
        };*/
    }

    public Node BuildTree()
    {
        var records = dbContext.Records.ToList();

        var root = new Node
        {
            Id = 0,
            Children = new List<Node>()
        };

        BuildTreeRecursive(root, records);

        return root;
    }

    private void BuildTreeRecursive(Node parentNode, ICollection<Record> records)
    {
        foreach (var record in records)
        {
            if (record.Parent == parentNode.Id)
            {
                var childNode = new Node
                {
                    Id = record.Id,
                    Children = new List<Node>()
                };
                
                //Somente adiciona se Children diferente Null
                parentNode.Children?.Add(childNode);
                
                BuildTreeRecursive(childNode, records);
            }
        }
    }

    public void PrintNodeRecursive(Node node, string indent = "")
    {
        if (node == null) return;

        Console.WriteLine(indent + node.Id);

        if (node.Children != null) 
            foreach (var child in node.Children) 
                PrintNodeRecursive(child, indent + "  ");
    }
}
