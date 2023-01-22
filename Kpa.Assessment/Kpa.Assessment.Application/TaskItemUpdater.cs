using System;
using System.Threading.Tasks;
using Kpa.Assessment.Application.Entities;
using Kpa.Assessment.Application.Interfaces;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Application;

// stub
public class TaskItemUpdater : ITaskItemUpdater
{
    public async Task<Result<TaskItem>> Update()
    {
        throw new NotImplementedException();
    }
}