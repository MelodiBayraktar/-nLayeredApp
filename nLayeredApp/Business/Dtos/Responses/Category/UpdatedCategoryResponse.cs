namespace Business.Dtos.Responses.Category;

public class UpdatedCategoryResponse
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public DateTime? UpdatedDate { get; set; }
}