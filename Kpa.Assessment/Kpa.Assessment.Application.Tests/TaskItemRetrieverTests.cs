using Kpa.Assessment.Database;
using Kpa.Assessment.Shared;
using Moq;

namespace Kpa.Assessment.Application.Tests;

public class TaskItemRetrieverTests
{
    private TaskItemRetriever _retriever;

    private readonly Mock<ITaskItemRepository> _repository = new();

    [SetUp]
    // ensuring every test gets fresh instances to work with
    public void SetUp()
    {
        _retriever = new TaskItemRetriever(_repository.Object);
    }
    
    #region GetAll

    [Test]
    // the naming convention I use is:
    // <Method under test>_<expected behavior>_<state under test>
    // just a convention though, happy to use whatever convention is preferable 
    public async Task GetAll_ReturnsError_WhenRepoReturnsError()
    {
        // arrange
        var expectedStatus = ResultStatus.ProcessingError;
        _repository.Setup(x => x.GetAll())
            .ReturnsAsync(Result<IEnumerable<TaskItemRecord>>.Errored(expectedStatus, "err"));

        // act
        var actual = await _retriever.GetAll();

        // assert
        // first time I've ever seen this new constraint model syntax
        // not sure I like it, but it gives me warnings when I use the traditional asserts I'm used to
        // in a real world scenario, would discuss with them team what approach we'd want to use
        // and disable warnings if we decided we don't like the new syntax
        Assert.That(actual.Succeeded(), Is.False);
        Assert.That(actual.Status, Is.EqualTo(expectedStatus));
    }

    [Test]
    public async Task GetAll_ReturnsProcessingError_WhenDataReturnedFromRepoIsDirty()
    {
        // will cause a null ref error
        _repository.Setup(x => x.GetAll())
            .ReturnsAsync(Result<IEnumerable<TaskItemRecord>>.Success(null));

        var actual = await _retriever.GetAll();
        
        Assert.That(actual.Succeeded(), Is.False);
        Assert.That(actual.Status, Is.EqualTo(ResultStatus.ProcessingError));
    }
    
    // happy path
    [Test]
    public async Task GetAll_Success()
    {
        var retList = new[]
        {
            new TaskItemRecord
            {
                TaskItemId = 1,
                Title = "Get a Job at KPA",
                Description = "",
                AssigneeUserId = 1234,
                AssigneeUserName = "jmulla",
                CreatedOn = DateTimeOffset.UtcNow,
                UpdatedOn = DateTimeOffset.UtcNow,
            }
        };
        _repository.Setup(x => x.GetAll())
            .ReturnsAsync(Result<IEnumerable<TaskItemRecord>>.Success(retList));

        var actual = await _retriever.GetAll();
        
        Assert.That(actual.Succeeded());
        // basic check to make sure the number of items returned == to expected
        // ensuring properties are mapping correctly across objects would be tested in another test class
        // since mapping is done in another class
        Assert.That(actual.Content.Count, Is.EqualTo(retList.Length));
    }
    

    #endregion

    #region Get

    [Test]
    public async Task Get_ReturnsNotFound_WhenRecordNotFound()
    {
        _repository.Setup(x => x.Get(It.IsAny<int>()))
            .ReturnsAsync(Result<TaskItemRecord>.Errored(ResultStatus.MissingResource, "not found"));

        var actual = await _retriever.Get(-1);
        
        Assert.That(actual.Succeeded(), Is.False);
        Assert.That(actual.Status, Is.EqualTo(ResultStatus.MissingResource));
    }
    
    [Test]
    // exception will be thrown in app layer, handled, and surfaced as a processing error (translates to 500 status code)
    public async Task Get_ReturnsProcessingError_WhenDataReturnedFromRepoIsDirty()
    {
        _repository.Setup(x => x.Get(It.IsAny<int>()))
            .ReturnsAsync(Result<TaskItemRecord>.Success(null));

        var actual = await _retriever.Get(-1);
        
        Assert.That(actual.Succeeded(), Is.False);
        Assert.That(actual.Status, Is.EqualTo(ResultStatus.ProcessingError));
    }

    [Test]
    public async Task Get_Success()
    {
        _repository.Setup(x => x.Get(It.IsAny<int>()))
            .ReturnsAsync(new TaskItemRecord
            {
                TaskItemId = 1,
                Title = "Get a Job at KPA",
                Description = "",
                AssigneeUserId = 1234,
                AssigneeUserName = "jmulla",
                CreatedOn = DateTimeOffset.UtcNow,
                UpdatedOn = DateTimeOffset.UtcNow,
            });

        var actual = await _retriever.Get(-1);
        
        Assert.IsTrue(actual.Succeeded());
        Assert.NotNull(actual.Content);
    }

    #endregion
}