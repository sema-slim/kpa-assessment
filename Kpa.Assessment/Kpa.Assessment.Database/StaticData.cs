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
            Description = "KPA seems like a great place to work, and the need for OSHA compliance isn't going out of fashion any time soon",
            AssigneeUserId = 1234,
            AssigneeUserName = "jmulla",
            CreatedOn = DateTimeOffset.UtcNow,
            UpdatedOn = DateTimeOffset.UtcNow,
        },
        new TaskItemRecord
        {
            TaskItemId = 2,
            Title = "Become a pro at angular",
            Description = "Angular is among the most popular ui frameworks in use today. Having experience in it would make a great addition to your existing tool kit",
            CreatedOn = DateTimeOffset.UtcNow,
            UpdatedOn = DateTimeOffset.UtcNow,
        },
    };
}