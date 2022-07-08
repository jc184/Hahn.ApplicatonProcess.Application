using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Web.DTOs.Assets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Services.Assets
{
    public class AssetsService : BaseService
    {

        public AssetsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<AddAssetResponse> AddNewAsync(AddAssetRequest model)
        {
            var asset = new Asset(
                model.AssetId
                , model.Name
                , model.Symbol
                , model.UserId);

            var repository = UnitOfWork.AsyncRepository<Asset>();

            await repository.AddAsync(asset);

            await UnitOfWork.SaveChangesAsync();

                var response = new AddAssetResponse()
                {
                    Id = asset.Id,
                    AssetId = asset.Asset_Id,
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
                AssetId= _.Asset_Id,
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
                    AssetId = _.Asset_Id,
                    Name = _.Name,
                    Symbol = _.Symbol,
                    UserId = _.UserId,
                })
                .ToList();

            if (assetDTOs.Count > 0)
            {

                return assetDTOs;
            }
            else
            {
                return null;
            }
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
               AssetId = asset.Asset_Id,
               Name = asset.Name,
               Symbol = asset.Symbol,
               UserId = asset.UserId,
            };

            return response;
        }

        public async Task<UpdateAssetResponse> UpdateAsync(UpdateAssetRequest model, int Id)
        {
            var entity = await UnitOfWork.AsyncRepository<Asset>()
                                .FindAsync(entity => entity.Id == Id);

            entity.Asset_Id = model.AssetId;
            entity.Name = model.Name;
            entity.Symbol = model.Symbol;
            entity.UserId = model.UserId;

            
            var repository = UnitOfWork.AsyncRepository<Asset>();
            await repository.UpdateAsync(entity);
            await UnitOfWork.SaveChangesAsync();

            var response = new UpdateAssetResponse()
            {
                Id = entity.Id,
                AssetId = model.AssetId,
                Name = entity.Name,
                Symbol = entity.Symbol,
                UserId = entity.UserId,
            };

            return response;
        }

    }
}
