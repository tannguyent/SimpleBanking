using AutoMapper;
using Banking.API.Infrastructure.Database.Models;
using Banking.API.Infrastructure.Service.Models;

namespace Banking.API.Infrastructure.Service.MapperProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<BankingAccount, BankingAccountModel>();
            CreateMap<Transaction, TransactionModel>()
                .ForMember(c=>c.Status, opt => opt.MapFrom(c=>(int)c.Status));

            CreateMap<TransactionHistory, TransactionHistoryModel>();
        }
    }
}
