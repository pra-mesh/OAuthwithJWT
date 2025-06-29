using System.ComponentModel.DataAnnotations;

namespace OAuthwithJWT.Models;

public class Test
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string? Title { get; set; }
}
