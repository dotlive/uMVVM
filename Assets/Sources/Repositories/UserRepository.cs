using UnityEngine;

namespace Assets.Sources.Repositories
{
    public class UserRepository:IUserRepository
    {
        public void Add()
        {
           Debug.Log("UserRepository");
        }
    }
}
