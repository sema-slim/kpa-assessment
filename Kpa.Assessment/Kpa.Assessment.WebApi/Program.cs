using Kpa.Assessment.Application;
using Kpa.Assessment.Application.Interfaces;
using Kpa.Assessment.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// I would generally register dependencies in a separate class to help keep things organized
// since this is a really small api, just doing it here

// not actually accessing a real db from this repo, but using a singleton since in a real world
// scenario would only want one instance opening db connections
builder.Services.AddSingleton<ITaskItemRepository, TaskItemRepository>();

// outside of scenarios where a singleton is required (db, service bus, etc), I generally register everything as
// transient to allow for seamless use of http client factory; i.e. avoiding the scenario where an httpclient
// is held onto by a singleton instance
builder.Services.AddTransient<ITaskItemRetriever, TaskItemRetriever>();

builder.Services.AddTransient<ITaskItemCreator, TaskItemCreator>();
builder.Services.AddTransient<ITaskItemUpdater, TaskItemUpdater>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.MapControllers();

app.Run();