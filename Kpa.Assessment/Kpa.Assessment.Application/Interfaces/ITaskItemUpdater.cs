using System.Threading.Tasks;
using Kpa.Assessment.Application.Entities;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Application.Interfaces;

public interface ITaskItemUpdater
{
    Task<Result<TaskItem>> Update();
}