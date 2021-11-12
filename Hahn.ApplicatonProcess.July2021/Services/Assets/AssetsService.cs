using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using Hahn.ApplicatonProcess.July2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.July2021.Web.DTOs.Assets;
using System;
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
                 model.Name
                , model.Symbol
                , model.UserId);

            var repository = UnitOfWork.AsyncRepository<Asset>();
            await repository.AddAsync(asset);
            await UnitOfWork.SaveChangesAsync();

            var response = new AddAssetResponse()
            {
                Id = asset.Id,
                Name = asset.Name,
                Symbol = asset.Symbol,
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



    }
}
