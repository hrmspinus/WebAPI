using HRMS.Repository;
using HRMS.WebAPI.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddTransient<IDesignationRepository, DesignationRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<IAddressTypeRepository, AddressTypeRepository>();
builder.Services.AddTransient<IApplyLeaveRepository, ApplyLeaveRepository>();
builder.Services.AddTransient<IAppraisalObjectivesRepository, AppraisalObjectivesRepository>();
builder.Services.AddTransient<IHrmsRoleRepository, HrmsRoleRepository>();
builder.Services.AddTransient<IHrmsUserRepository, HrmsUserRepository>();
builder.Services.AddTransient<IHrmsPageRepository, HrmsPageRepository>();
builder.Services.AddTransient<IBloodGroupRepository, BloodGroupRepository>();
builder.Services.AddTransient<IClaimTypeRepository, ClaimTypeRepository>();
builder.Services.AddTransient<ILocationRepository, LocationRepository>();
builder.Services.AddTransient<IRelationShipRepository, RelationShipRepository>();
builder.Services.AddTransient<IEmployeeDetailsRepository, EmployeeDetailsRepository>();
builder.Services.AddTransient<IEmployeeExperienceRepository, EmployeeExperienceRepository>();
builder.Services.AddTransient<IEmployeeFamilyDetailsRepository, EmployeeFamilyDetailsRepository>();
var app = builder.Build();
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
     );
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
