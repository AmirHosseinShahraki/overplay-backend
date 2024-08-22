namespace Domain.Entities;

public class CoverImageFile : File
{
    public override string ToString()
    {
        return Url;
    }
};