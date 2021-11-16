using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Web.DTOs.Assets;
using Hahn.ApplicatonProcess.July2021.Web.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.July2021.Web.Extensions;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.July2021.Data;

namespace Hahn.ApplicatonProcess.July2021.Web.Services.Assets
{
    public class AssetsService : BaseService
    {
        private DbSet<Asset> _dbSet;

        public AssetsService(IUnitOfWork unitOfWork, EFDBContext dbContext) : base(unitOfWork)
        {
            _dbSet = dbContext.Set<Asset>();
        }

        public async Task<AddAssetResponse> AddNewAsync(AddAssetRequest model)
        {
            var asset = new Asset(
                model.AssetId
                , model.Name
                , model.Symbol
                , model.UserId);

            var repository = UnitOfWork.AsyncRepository<Asset>();

            await repository.AddIfNotExists(_dbSet, asset, x => x.Id == model.AssetId);

            await UnitOfWork.SaveChangesAsync();

                var response = new AddAssetResponse()
                {
                    Id = asset.Id,
                    Name = asset.Name,
                    Symbol = asset.Symbol,
                    UserId = asset.UserId,
                };

            return response;

        }

        public async Task<List<AssetInfoDTO>> GetAllAsync()
        {

            var repository = UnitOfWork.AsyncRepository<Asset>();
            var assets = await repository.ListAllAsync();

            var assetDTOs = assets.Select(_ => new AssetInfoDTO()
            {
                Id = _.Id,
                Name = _.Name,
                Symbol = _.Symbol,
                UserId = _.UserId
            })
            .ToList();

            return assetDTOs;
        }

        public async Task<List<AssetInfoDTO>> SearchAsync(GetAssetListRequest request)
        {
            var repository = UnitOfWork.AsyncRepository<Asset>();
            var assets = await repository
                .ListAsync(_ => _.Symbol.Contains(request.Search));

            var assetDTOs = assets.Select(_ => new AssetInfoDTO()
            {
                Id = _.Id,
                Name = _.Name,
                Symbol= _.Symbol,
                UserId  = _.UserId,
            })
            .ToList();

            return assetDTOs;
        }

        public async Task<DeleteAssetResponse> DeleteAsync(DeleteAssetRequest request)
        {

            var repository = UnitOfWork.AsyncRepository<Asset>();
            var asset = await repository.GetAsync(_ => _.Id.Equals(request.Id));
            var assets = await repository.DeleteAsync(asset);
            await UnitOfWork.SaveChangesAsync();

            var response = new DeleteAssetResponse()
            {
               Id = asset.Id,
               Name = asset.Name,
               Symbol = asset.Symbol,
               UserId = asset.UserId,
            };

            return response;
        }

        public async Task<UpdateAssetResponse> UpdateAsync(UpdateAssetRequest model, string Id)
        {
            var entity = await UnitOfWork.AsyncRepository<Asset>()
                                .FindAsync(entity => entity.Id.Equals(Id));

            entity.Name = model.Name;
            entity.Symbol = model.Symbol;
            entity.UserId = model.UserId;

            
            var repository = UnitOfWork.AsyncRepository<Asset>();
            await repository.UpdateAsync(entity);
            await UnitOfWork.SaveChangesAsync();

            var response = new UpdateAssetResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Symbol = entity.Symbol,
                UserId = entity.UserId,
            };

            return response;
        }

    }
}
