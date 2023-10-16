using TreeSharp.Models;

namespace TreeSharp.Services;

public class TreeBuilderService
{

    private ICollection<Record> Records { get; set; }


    public TreeBuilderService()
    {
        Records = new List<Record>
        {
            new() {
                Id = 0,
                Parent = 0,
            }
        };
    }

    public Node Build()
    {

        /// Criar a lógica


        return new Node();
    }

}
