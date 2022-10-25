using JsonPatchSample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); // Added "AddNewtonsoftJson" for PATCH functionality, original: builder.Services.AddControllers();



//builder.Services.AddControllers(options => {
//    options.InputFormatters.Insert(0, RestrictNewtonsoftJson.GetJsonPatchInputFormatter());
//}); // Added "AddNewtonsoftJson" for PATCH functionality, probably better approach but Swagger doesn't like it, original: builder.Services.AddControllers();



builder.Services.AddDbContext<DataContext>(options => { //Connect to the datacontext

    options.UseSqlServer(builder.Configuration.GetConnectionString("NiklasLocalConnection")); //Connect to the connection string to use
    
} );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
