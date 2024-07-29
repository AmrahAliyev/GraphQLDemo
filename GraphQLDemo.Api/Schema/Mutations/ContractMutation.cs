using GraphQLDemo.Api.Model.Entities;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.Api;

public class ContractMutation
{
    private readonly IContractRepository _contractRepository;

    public ContractMutation(IContractRepository cotractService)
    {
        _contractRepository = cotractService;
    }
    public async Task<bool> AddContract(string contractNumber, Guid userId, ITopicEventSender topicEventSender)
    {
        Contract contract = new Contract()
        {
            Id = Guid.NewGuid(),
            ContractNumber = contractNumber,
            UserId = userId
        };
        await topicEventSender.SendAsync(nameof(Subscription.ContractCreated), contract);
        return await _contractRepository.AddContract(contract);
    }
}