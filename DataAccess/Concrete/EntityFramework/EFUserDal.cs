using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user) //Verilen Kullanıcı id'sine göre OperaionClaim'ler !!!!!
        {
            using (var context = new RentACarContext())
            {

                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.OperationClaimId equals uoc.UserOperationClaimId
                             where uoc.UserId == user.UserId
                             select new OperationClaim
                             {
                                 OperationClaimId = oc.OperationClaimId,
                                 Name = oc.Name //?
                             };
                return result.ToList(); 
            }
        }
    }
}
