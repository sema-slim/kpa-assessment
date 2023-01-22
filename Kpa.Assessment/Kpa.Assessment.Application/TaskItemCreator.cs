using System;
using System.Threading.Tasks;
using Kpa.Assessment.Application.Entities;
using Kpa.Assessment.Application.Interfaces;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Application;

public class TaskItemCreator : ITaskItemCreator
{
    // stub
    public async Task<Result<TaskItem>> Create()
    {
        throw new NotImplementedException();
    }
}