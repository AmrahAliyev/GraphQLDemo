
using GraphQLDemo.Api;
using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Repositories;
using GraphQLDemo.Api.Repositories.Interfaces;
using GraphQLDemo.Api.Schema.Mutations;
using GraphQLDemo.Api.Schema.Queries;
using GraphQLDemo.Api.Services;
using GraphQLDemo.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services
.AddScoped<IUserRepository, UserRepository>()
.AddScoped<IContractRepository, ContractRepository>()
.AddGraphQLServer()
.AddQueryType<Query>()
.AddMutationType<Mutation>()
;

builder.Services.AddScoped<UserQuery>();
builder.Services.AddScoped<UserMutation>();

builder.Services.AddScoped<ContractQuery>();
builder.Services.AddScoped<ContractMutation>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContractService, ContractService>();



var app = builder.Build();



app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();

