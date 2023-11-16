using EKO.RaspberryPi.AppLogic.Services.Contracts;

namespace EKO.RaspberryPi.AppLogic.Services;

public class ArticleHandler : IArticleHandler
{
    private readonly string[] _allowedFiles;
    private const string BLOG_DIRECTORY = "/app/blog_articles";

    public ArticleHandler()
    {
        var files = Directory.EnumerateFiles(BLOG_DIRECTORY);

        var filteredFiles = new List<string>();

        foreach (var file in files)
        {
            var extension = Path.GetExtension(file);

            if (extension == ".md")
            {
                filteredFiles.Add(file);
            }
        }

        _allowedFiles = filteredFiles.ToArray();
    }

    public FileStream? GetBlogArticleAsMarkdown(string articleName)
    {
        var fileName = BLOG_DIRECTORY + "/" + articleName;

        if (!_allowedFiles.Contains(fileName))
            return null;

        var fileStream = File.OpenRead(fileName);

        return fileStream;
    }
}
