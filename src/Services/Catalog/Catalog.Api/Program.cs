var builder = WebApplication.CreateBuilder(args);

//Add or Register to the container
//builder.Services.AddCarter();

builder.Services.AddCarter(new DependencyContextAssemblyCatalog(typeof(Program).Assembly));


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly); // this will register all the handlers in the assembly where Program.cs is located
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();
app.MapGet("/", () => "Hello World!");
app.Run();
