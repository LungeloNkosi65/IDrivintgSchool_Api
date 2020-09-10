using DrivingSchool_Api;
using Models.ViewModels;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Implementations
{
    public class PackageInclusionRepository : IPackageInclusionRepository
    {
        private readonly IDapperBaseRepository _dapperBaseRepository;

        public PackageInclusionRepository(IDapperBaseRepository dapperBaseRepository)
        {
            _dapperBaseRepository = dapperBaseRepository;
        }
        public bool Add(PackageInclusions entity)
        {
            var sqlcommand = "AddPackageInclusion";
            var parameters =new
            {
                entity.Description
            };
            var resluts= _dapperBaseRepository.Execute(sqlcommand, parameters);
            return resluts == 0;
        }

        public bool Delete(object id)
        {
            string sqlcommand = "DeletePackageInclusion";
            var parameter = new { id };
            var results = _dapperBaseRepository.Execute(sqlcommand, parameter);
            return results == 0;
        }
        public IQueryable<PackageInclusions> GetAll()
        {
            string sqlcommand = "GetPackageInclusion";
            return _dapperBaseRepository.Query<PackageInclusions>(sqlcommand);
        }

        public IQueryable<PackageInclusionVm> GetInclusionForPackage(int? bkpId)
        {
            string sqlcommand = "PackageInclusion_Details";
            var parameter = new { bkpId };
            var results = _dapperBaseRepository.QueryWithParameter<PackageInclusionVm>(sqlcommand, parameter);
            return results;
        }

        public IQueryable<PackageInclusions> GetSingleRecord(object id)
        {
            string sqlcommand = "GetSinglePackageInclusion";
            var parameter = new { id };
            var results = _dapperBaseRepository.QuerySingl<PackageInclusions>(sqlcommand, parameter);
            return results;
        }

        public bool Update(PackageInclusions entity)
        {
            string sqlcommand = "UpdatePackageInclusion";
            var parameter = new { entity.InclusionId, entity.Description };
            var results = _dapperBaseRepository.Execute(sqlcommand,parameter);
            return results == 0;
        }
    }
}
