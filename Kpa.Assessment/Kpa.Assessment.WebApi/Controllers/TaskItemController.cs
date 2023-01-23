using Kpa.Assessment.Application;
using Kpa.Assessment.Application.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Kpa.Assessment.WebApi.Controllers;

[ApiController]
[Route("TaskItems")]
public class TaskItemController : Controller
{
    private readonly ITaskItemRetriever _retriever;
    private readonly ITaskItemCreator _creator;
    private readonly ITaskItemUpdater _updater;

    public TaskItemController(ITaskItemRetriever retriever, ITaskItemCreator creator, ITaskItemUpdater updater)
    {
        _retriever = retriever;
        _creator = creator;
        _updater = updater;
    }

    // my goal is to always keep my controller methods as small as possible
    // in a real world scenario, I might add some logging context but that's about it
    // application layer classes should be handling exceptions - hence no try/catches here
    [HttpGet("")]
    public async Task<IActionResult> GetAllTaskItems()
    {
        return await _retriever.GetAll()
            .ToHttpJsonResponse();
    }

    // 1 or 2 will work
    [HttpGet("{taskItemId}")]
    public async Task<IActionResult> GetById(int taskItemId)
    {
        return await _retriever.Get(taskItemId)
            .ToHttpJsonResponse();
    }

    // stub
    [HttpPost("")]
    public async Task<IActionResult> Create()
    {
        return await _creator.Create()
            .ToHttpJsonResponse();
    }
    
    // stub
    [HttpPost("{taskItemId}/update")]
    public async Task<IActionResult> Update()
    {
        return await _updater.Update()
            .ToHttpJsonResponse();
    }
}