namespace Business.Dtos.Responses;

public class DeletedProductResponse
{
    public int Id { get; set; }
    public string ProductName { get; set; } 
    public DateTime? DeletedDate { get; set; }
    
}