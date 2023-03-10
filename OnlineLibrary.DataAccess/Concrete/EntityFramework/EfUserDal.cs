using OnlineLibrary.Core.DataAccess.EntityFramework;
using OnlineLibrary.Core.Entities;
using OnlineLibrary.DataAccess.Abstract;
using OnlineLibrary.DataAccess.Concrete.EntityFramework.Contexts;

namespace OnlineLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, OnlineLibraryContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new OnlineLibraryContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
