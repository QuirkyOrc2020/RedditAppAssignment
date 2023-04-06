
using System.Text.Json;
using Domain.Models;


namespace FileData;

public class FileContext
{
    private const string FilePath = "data.json";

    private DataContainer? _dataContainer;
    
    public ICollection<Post> Posts
    {
        get
        {
            LoadData();
            return _dataContainer!.Posts;
        }
    }
    public ICollection<User?> Users
    {
        get
        {
            LazyLoadData();
            return _dataContainer!.Users;
        }
    }

    public ICollection<SubForum?> SubForums
    {
        get
        {
            LazyLoadData();
            return _dataContainer!.SubForums;
        }
        
    }
    public ICollection<Comment?> Comments
    {
        get
        {
            LazyLoadData();
            return _dataContainer!.Comments;
        }
        
    }

    private void LazyLoadData()
    {
        if (_dataContainer == null)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        if (_dataContainer != null) return;
        
        if (!File.Exists(FilePath))
        {
            _dataContainer = new ()
            {
                Users = new List<User>(),
                SubForums = new List<SubForum>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>()
            };
            return;
        }
        string content = File.ReadAllText(FilePath);
        _dataContainer = JsonSerializer.Deserialize<DataContainer>(content, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(_dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(FilePath, serialized);
        _dataContainer = null;
    }
}