namespace GraphQLDemo.Api;

public class ContractMutation
{
    private readonly IContractService _contractService;

    public ContractMutation(IContractService cotractService)
    {
        _contractService = cotractService;
    }
    public async Task<bool> AddContract(string contractNumber, Guid userId)
    {
        return await _contractService.AddContract(contractNumber, userId);
    }
}