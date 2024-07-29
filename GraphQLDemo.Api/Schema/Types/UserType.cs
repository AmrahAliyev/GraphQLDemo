using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Model.DTOs;
using GraphQLDemo.Api.Model.Entities;
using GraphQLDemo.Api.Services.Interfaces;

namespace GraphQLDemo.Api.Schema.Types
{
  public class UserType : ObjectType<UserDto>
    {
        protected override void Configure(IObjectTypeDescriptor<UserDto> descriptor)
        {
            descriptor.Field(u => u.Id).Type<NonNullType<IdType>>();
            descriptor.Field(u => u.Name).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.Email).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.Contracts)
                .ResolveWith<UserResolvers>(u => u.GetContractsAsync(default, default, default, default))
                .UseDbContext<AppDbContext>()
                .Name("contracts");
        }

        private class UserResolvers
        {
            public async Task<IEnumerable<ContractDto>> GetContractsAsync(
                UserDto user,
                [Service] IUserService userService,
                [Service] ContractByUserDataLoader contractLoader,
                CancellationToken cancellationToken)
            {
                return await userService.GetContractsByUserId(user.Id);
            }
        }
    }


}