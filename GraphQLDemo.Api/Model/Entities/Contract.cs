using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Api.Model.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string ContractNumber { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

    }
}