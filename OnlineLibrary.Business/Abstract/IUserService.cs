using OnlineLibrary.Core.Entities;

namespace OnlineLibrary.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
