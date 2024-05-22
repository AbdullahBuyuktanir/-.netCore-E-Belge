using E_Belge.API.Middlewares;
using E_Belge.Business.Registration;
using E_Belge.Business.Utilities.AutoMapper;
using E_Belge.Repositories.Registration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddValidatorsFromAssemblyContaining<CreateUpdateCariDto>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllersWithViews();/**/
builder.Services.AddRazorPages();/**/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapRazorPages();/**/
app.MapControllers();
app.MapFallbackToFile("index.html");/**/

app.Run();
