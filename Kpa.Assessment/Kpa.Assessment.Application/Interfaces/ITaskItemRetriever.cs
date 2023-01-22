using System.Collections.Generic;
using System.Threading.Tasks;
using Kpa.Assessment.Application.Entities;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Application.Interfaces;

public interface ITaskItemRetriever
{
    Task<Result<List<TaskItem>>> GetAll();
    Task<Result<TaskItem>> Get(int id);
}