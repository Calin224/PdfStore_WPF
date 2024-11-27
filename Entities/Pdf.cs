namespace StudyStash.Entities;

public class Pdf
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public byte[] FileData { get; set; }
    public string FilePath { get; set; }
    public DateTime DateAdded { get; set; }
    public string Category { get; set; }
}