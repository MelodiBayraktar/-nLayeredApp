namespace Business.Dtos.Responses.Category;

public class GetListedCategoryResponse
{
    
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}