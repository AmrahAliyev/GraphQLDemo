
using GraphQLDemo.Api;
using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Repositories;
using GraphQLDemo.Api.Repositories.Interfaces;
using GraphQLDemo.Api.Schema.Mutations;
using GraphQLDemo.Api.Schema.Queries;
using GraphQLDemo.Api.Schema.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddGraphQLServer()
       .AddQueryType<Query>()
       .AddMutationType<Mutation>()
       .AddType<UserType>()
       .AddType<ContractType>()
       .AddType<UserQuery>()
       .AddType<ContractQuery>()
       .AddType<UserMutation>()
       .AddType<ContractMutation>()
       .AddSubscriptionType<Subscription>()
       .AddInMemorySubscriptions() // This adds the in-memory subscription provider
       .AddDataLoader<ContractByUserDataLoader>();

builder.Services.AddScoped<UserQuery>();
builder.Services.AddScoped<UserMutation>();

builder.Services.AddScoped<ContractQuery>();
builder.Services.AddScoped<ContractMutation>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseWebSockets();
app.MapGraphQL();
app.Run();

