using System;

namespace Kpa.Assessment.Database;

// public get/set to allow serialization/deserialization between app and db
public class TaskItemRecord
{
    public int TaskItemId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? AssigneeUserId { get; set; }
    public string AssigneeUserName { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
}