using MOEIRCNet.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MOEIRCNet.API
{
    public interface IApi
    {
        Task<Session> Login(string login, string password);
        Task<Account> GetAccountAsync(Session session);
        Task Send(Counter counter, Session session);
    }
}
