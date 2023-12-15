namespace Business.Dtos.Responses.Category;

public class DeletedCategoryResponse
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public DateTime? DeletedDate { get; set; }
}