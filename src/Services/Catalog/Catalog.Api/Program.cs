using JasperFx;

var builder = WebApplication.CreateBuilder(args);

//Add or Register services to the container for DI
builder.Services.AddCarter();

//builder.Services.AddCarter(new DependencyContextAssemblyCatalog(typeof(Program).Assembly)); //

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly); // this will register all the handlers in the assembly where Program.cs is located
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
    options.AutoCreateSchemaObjects = AutoCreate.All;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();
app.MapGet("/", () => "Hello World!");
app.Run();
