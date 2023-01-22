using System;
using System.Collections.Generic;
using Kpa.Assessment.Database;

namespace Kpa.Assessment.Shared;

public static class StaticData
{
    public static IEnumerable<TaskItemRecord> SampleData() => new[]
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
        },
        new TaskItemRecord
        {
            TaskItemId = 2,
            Title = "Become a pro at angular",
            Description = "",
            CreatedOn = DateTimeOffset.UtcNow,
            UpdatedOn = DateTimeOffset.UtcNow,
        },
    };
}