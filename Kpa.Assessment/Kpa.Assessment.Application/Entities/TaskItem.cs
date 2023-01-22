using System;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Application.Entities;

public class TaskItem
{
    public int TaskItemId { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public User Assignee { get; private set; }
    public DateTimeOffset CreatedOn { get; }
    public DateTimeOffset UpdatedOn { get; private set; }

    public TaskItem(int id, 
        string title, 
        string description, 
        User assignee, 
        DateTimeOffset createdOn, 
        DateTimeOffset updatedOn)
    {
        TaskItemId = id;
        Title = title;
        Description = description;
        Assignee = assignee;
        CreatedOn = createdOn;
        UpdatedOn = updatedOn;
    }

    // enforce business logic in business entity
    // these setter methods would be used during entity updates before subsequently saving to db
    // to ensure correct creation logic, I would introduce a static factory method to validate inputs
    // would also add request validation logic for incoming requests whenever any data is being written
    public Result SetTitle(string title)
    {
        // maps to 400 bad request
        if(string.IsNullOrWhiteSpace(title))
            return Result.Errored(ResultStatus.InvalidRequest, "Title is a required field");

        Title = title;
        UpdatedOn = DateTimeOffset.UtcNow;
        return Result.Success();
    }

    // void method since nothing validated here
    public void SetDescription(string desc)
    {
        Description = desc;
        UpdatedOn = DateTimeOffset.UtcNow;
    }

    // void method since nothing validated here
    public void Unassign()
    {
        Assignee = null;
        UpdatedOn = DateTimeOffset.UtcNow;
    }
}