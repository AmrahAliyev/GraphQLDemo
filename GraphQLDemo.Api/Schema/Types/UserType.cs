using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Model.Entities;
using GraphQLDemo.Api.Repositories.Interfaces;

namespace GraphQLDemo.Api.Schema.Types
{
    // UserType
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(u => u.Id).Type<NonNullType<IdType>>();
            descriptor.Field(u => u.Name).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.Email).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.Contracts)
                .UseDbContext<AppDbContext>()
                .Name("contracts");
        }
    }
}