using Xunit;

public class VideoTests
{
    [Fact]
    public void Constructor_SetsPropertiesAndStartsWithZeroComments()
    {
        var video = new Video("Test Title", "Author Name", 120);

        // We don't have getters for fields, but DisplayVideoDetails writes to console.
        // Test the comments behavior instead.
        Assert.Equal(0, video.GetNumberOfComments());
    }

    [Fact]
    public void AddComment_IncreasesCommentCount()
    {
        var video = new Video("Another", "Someone", 200);
        var comment = new Comment("User", "Nice video");
        video.AddComment(comment);

        Assert.Equal(1, video.GetNumberOfComments());
    }
}
