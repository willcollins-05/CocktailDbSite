using System.ComponentModel.DataAnnotations.Schema;

namespace CocktailDbSite.Domain.Models;

// THIS TABLE IS ONLY USED FOR TESTING THE CONNECTION OF THE DATABASE.
// THIS IS TO BE REMOVED ONCE ALL TEAM MEMBERS CONFIRM A WORKING DATABASE CONNECTION
[Table("test_table")]
public class TestTable
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("test_col")]
    public string? TestCol { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(TestCol)}: {TestCol}";
    }
}