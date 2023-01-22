using Kpa.Assessment.Application.Entities;
using Kpa.Assessment.Database;

namespace Kpa.Assessment.Application;

public static class RecordExtensions
{
    // convenience method for converting to appropriate class type
    // when moving between project layers
    // domain = business entity
    // record = db entity
    public static TaskItem ToDomain(this TaskItemRecord record)
    {
        // no userId means no assignee
        var assignee = record.AssigneeUserId.HasValue
            ? new User(record.AssigneeUserId.Value, record.AssigneeUserName)
            : null;
        
        return new TaskItem(record.TaskItemId, 
            record.Title, 
            record.Description, 
            assignee, 
            record.CreatedOn, 
            record.UpdatedOn);
    }
}