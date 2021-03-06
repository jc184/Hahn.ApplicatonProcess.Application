using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Web.DTOs.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Services.Users
{
    public class UserService : BaseService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<AddUserResponse> AddNewAsync(AddUserRequest model)
        {
            var user = new User(
                 model.FirstName
                , model.LastName
                , model.Address
                , model.Age
                , model.Email);

            var repository = UnitOfWork.AsyncRepository<User>();
            await repository.AddAsync(user);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddUserResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email
            };

            return response;
        }

        public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest model, int Id)
        {
            var entity = await UnitOfWork.AsyncRepository<User>()
                                .FindAsync(entity => entity.Id == Id);


            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Address = model.Address;
            entity.Email = model.Email;
            entity.Age = model.Age;


            var repository = UnitOfWork.AsyncRepository<User>();
            await repository.UpdateAsync(entity);
            await UnitOfWork.SaveChangesAsync();

            var response = new UpdateUserResponse()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Age = entity.Age,
                Email = entity.Email
            };

            return response;
        }


        public async Task<List<UserInfoDTO>> SearchAsync(GetUserRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<User>();
            var users = await repository
                .ListAsync(_ => _.Email.Contains(request.Search));

            var userDTOs = users.Select(_ => new UserInfoDTO()
            {
                Address = _.Address,
                FirstName = _.FirstName,
                Id = _.Id,
                LastName = _.LastName,
                Email = _.Email,
                Age = _.Age,
            })
            .ToList();

            if (userDTOs.Count > 0)
            {

                return userDTOs;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<GetAllUsersResponse>> GetAllAsync()
        {

            var repository = UnitOfWork.AsyncRepository<User>();
            var users = await repository.GetAllAsync(en => en.Assets).ConfigureAwait(false);

            var userDTOs = users.Select(_ => new GetAllUsersResponse()
            {
                Address = _.Address,
                FirstName = _.FirstName,
                Id = _.Id,
                LastName = _.LastName,
                Email = _.Email,
                Age = _.Age,
                Assets = _.Assets.ToList<Asset>(),
            })
            .ToList();

            return userDTOs;
        }

        public async Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest request)
        {

            var repository = UnitOfWork.AsyncRepository<User>();
            var user = await repository.GetAsync(_ => _.Id.Equals(request.Id));
            var users = await repository.DeleteAsync(user);
            await UnitOfWork.SaveChangesAsync();

            var response = new DeleteUserResponse()
            {
                Id = user.Id,
                Email = user.Email
            };

            return response;
        }
    }
}
