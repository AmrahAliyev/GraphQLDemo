using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Api.Model.DTOs
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public string ContractNumber { get; set; } = null!;
        public UserDto User { get; set; } = null!;
    }
}