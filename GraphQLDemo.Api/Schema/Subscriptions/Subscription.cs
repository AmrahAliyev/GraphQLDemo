using GraphQLDemo.Api.Model.DTOs;
using GraphQLDemo.Api.Model.Entities;

namespace GraphQLDemo.Api;

public class Subscription
{
    [Subscribe]
    public Contract ContractCreated([EventMessage] Contract contract) 
    => contract;
}
