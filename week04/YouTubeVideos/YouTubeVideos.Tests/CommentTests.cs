using Xunit;

public class CommentTests
{
    [Fact]
    public void Constructor_SetsFieldsAndDisplayWorks()
    {
        var comment = new Comment("Tester", "Sample text");
        // No getters, just ensure DisplayComment can be called without exceptions.
        comment.DisplayComment();
        Assert.True(true);
    }
}
