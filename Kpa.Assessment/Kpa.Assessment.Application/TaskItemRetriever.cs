using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kpa.Assessment.Application.Entities;
using Kpa.Assessment.Application.Interfaces;
using Kpa.Assessment.Database;
using Kpa.Assessment.Shared;

namespace Kpa.Assessment.Application;

// I like to keep my app layer classes very small
// makes code management far easier and also keeps unit test classes smaller
public class TaskItemRetriever : ITaskItemRetriever
{
    private readonly ITaskItemRepository _repository;

    public TaskItemRetriever(ITaskItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<TaskItem>>> GetAll()
    {
        try
        {
            var result = await _repository.GetAll();
            if (result.Failed())
            {
                // for "get all" type methods, an empty collection is a success in my opinion
                // the only error we would expect to see here would be the result of an exception when connecting to the db
                return Result<List<TaskItem>>.Errored(result.Status, result.ErrorMessage);
            }

            // I would generally introduce a response object here to keep business entities separated from
            // responses we provide to consumer
            // didn't introduce any in this application in the interest of time
            return result.Content
                .Select(x => x.ToDomain())
                .ToList();
        }
        catch (Exception)
        {
            // would also log here in a real world scenario
            // really shouldn't ever be seeing exceptions here, but it's a fail safe in the event
            // that things go sideways when mapping from db record to business entity
            return Result<List<TaskItem>>.Errored(ResultStatus.ProcessingError, "An unexpected error occurred");
        }
        
    }

    public async Task<Result<TaskItem>> Get(int id)
    {
        try
        {
            var result = await _repository.Get(id);
            if (result.Failed())
            {
                // here we would expect to see an error if there's no corresponding record (not found)
                // or we failed to connect to the db
                return Result<TaskItem>.Errored(result.Status, result.ErrorMessage);
            }
        
            return result.Content.ToDomain();
        }
        catch (Exception)
        {
            return Result<TaskItem>.Errored(ResultStatus.ProcessingError, "An unexpected error occurred");
        }
    }
}