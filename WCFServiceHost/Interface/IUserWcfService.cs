using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceHost.Classe;

namespace WCFServiceHost
{
    
    [ServiceContract]
    public interface IUserWcfService
    {
        [OperationContract]
        List<UserWcf> GetAllUsers();

        [OperationContract]
        UserWcf GetUserById(int productId);

        [OperationContract]
        void AddUser(UserWcf product);

        [OperationContract]
        void UpdateUser(UserWcf product);

        [OperationContract]
        void DeleteUser(int productId);
    }
}
