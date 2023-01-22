using System.Threading.Tasks;
using Kpa.Assessment.Application.Entities;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Application.Interfaces;

public interface ITaskItemCreator
{
    Task<Result<TaskItem>> Create();
}