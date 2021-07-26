using SentryQualityManagement.Core.Entities;
using SentryQualityManagement.Core.Interfaces;
using System.Threading.Tasks;

namespace SentryQualityManagement.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Users> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.UserRepository.GetLoginByCredentials(userLogin);
        }


        public async Task RegisterUser(Users user)
        {
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}


