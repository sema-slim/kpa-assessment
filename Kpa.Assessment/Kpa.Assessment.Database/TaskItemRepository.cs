using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Database;

public class TaskItemRepository : ITaskItemRepository
{
    // obviously no need to make these methods async, just simulating async access to db
    // of course db access would be wrapped in a try/catch in a real world scenario
    // exceptions would become a result with a processing error status
    public async Task<Result<IEnumerable<TaskItemRecord>>> GetAll()
    {
        return Result<IEnumerable<TaskItemRecord>>.Success(StaticData.SampleData());
    }

    public async Task<Result<TaskItemRecord>> Get(int taskItemId)
    {
        var record = StaticData.SampleData()
            .FirstOrDefault(x => x.TaskItemId == taskItemId);

        return record ?? Result<TaskItemRecord>.Errored(ResultStatus.MissingResource, "TaskItem not found");
    }
}