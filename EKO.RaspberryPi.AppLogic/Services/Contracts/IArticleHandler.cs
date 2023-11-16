namespace EKO.RaspberryPi.AppLogic.Services.Contracts;

public interface IArticleHandler
{
    public FileStream? GetBlogArticleAsMarkdown(string articleName);
}
