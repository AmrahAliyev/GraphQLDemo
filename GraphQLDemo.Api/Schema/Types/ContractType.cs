using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Model.Entities;

namespace GraphQLDemo.Api;


public class ContractType : ObjectType<Contract>
{
    protected override void Configure(IObjectTypeDescriptor<Contract> descriptor)
    {
        descriptor.Field(u => u.Id).Type<NonNullType<IdType>>();
        descriptor.Field(u => u.ContractNumber).Type<NonNullType<StringType>>();
        descriptor.Field(u => u.User)
            .UseDbContext<AppDbContext>()
            .Name("user");
    }
}
