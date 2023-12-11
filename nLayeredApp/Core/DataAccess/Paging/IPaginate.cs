namespace Core.DataAccess.Paging;

public interface IPaginate<T>
{

    public  int Size { get;}
    public  int Index { get;}
    public  int Count { get;}
    public  int Pages { get; }
    public  int From { get;}
    public IList<T> Items { get;}
    public bool HasPrevious => Index > 0;
    public bool HasNext => Index+1 < Pages;
}