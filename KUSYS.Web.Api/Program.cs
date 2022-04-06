using AutoMapper;
using FluentValidation;
using KUSYS.Business.AutoMapping;
using KUSYS.Business.Service;
using KUSYS.Business.Validator;
using KUSYS.Core;
using KUSYS.Core.Contracts.DTOs;
using KUSYS.Core.Repository;
using KUSYS.Core.Service;
using KUSYS.Data;
using KUSYS.Data.Repository;
using KUSYS.Web.Api.Extensions;
using KUSYS.Web.Api.Authorization;
using KUSYS.Web.Api.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using KUSYS.Web.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

//builder.Logging.AddProvider(new FileLogProvider());

builder.Logging.AddEventLog();

var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetRequiredService<ILogger<MyCustomMiddleware>>();
builder.Services.AddSingleton(typeof(ILogger), logger);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<KUSYSContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"));
});

#region dependencies
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IValidator<StudentDTO>, StudentValidator>();
builder.Services.AddTransient<IValidator<CourseDTO>, CourseValidator>();
builder.Services.AddScoped<ILogger, FileLogger>();
builder.Services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();
#endregion

builder.Services.AddAutoMapper(typeof(Program).Assembly);
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddLogging();

builder.Services.AddMvc();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMyCustomMiddleware();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();