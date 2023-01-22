using System.Collections.Generic;
using System.Threading.Tasks;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Database;

public interface ITaskItemRepository
{
    Task<Result<IEnumerable<TaskItemRecord>>> GetAll();
    Task<Result<TaskItemRecord>> Get(int taskItemId);
}