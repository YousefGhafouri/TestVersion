using System;
using System.Collections.Generic;
using Dapper;
using Updater.DataAccess.Repositories;
using Updater.Entities;
using Updater.Model;
using TestVersion.Utilities;
using static TestVersion.Utilities.DataStructure;

namespace Updater.DataControl.Controllers
{
    public class VersionsController : IController<Versions, VersionsDto>
    {
        ICommandText commandText;
        private Repository<Versions> repository;
        public VersionsController()
        {
            commandText = new VersionsCommandText();
            repository = new Repository<Versions>(/*configuration,*/ commandText);
        }
        public Versions Add(VersionsDto versions)
        {
            return repository.Add(GetAddParameter(versions));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Dispose()
        {
            commandText = null;
            repository = null;
        }

        public List<VersionsDto> GetAll()
        {
            return repository.Get().ToXList<Versions, VersionsDto>();
        }

        public VersionsDto GetById(int id)
        {
            return repository.GetById(id).ToDto<Versions, VersionsDto>();
        }

        public Versions Save(DataStructure.FormAction formAction, VersionsDto versions)
        {
            if (formAction == FormAction.Add)
                return Add(versions);
            else
            {
                Update(versions);
                return null;
            }
        }

        public void Update(VersionsDto versions)
        {
            repository.Update(GetUpdateParameter(versions));
        }

        public string MaxCode()
        {
            return repository.MaxCode();
        }

        internal DynamicParameters GetAddParameter(VersionsDto versions)
        {
            return new DynamicParameters(new
            {
                VersionCode = versions.VersionCode,
                VersionName = versions.VersionName,
                DllPath = versions.DllPath,
                StructureScriptPath = versions.StructureScriptPath,
                AlterScriptPath = versions.AlterScriptPath,
                VersionDescription = versions.VersionDescription
            });
        }

        internal DynamicParameters GetUpdateParameter(VersionsDto versions)
        {
            return new DynamicParameters(new
            {
                ID = versions.ID,
                VersionCode = versions.VersionCode,
                VersionName = versions.VersionName,
                DllPath = versions.DllPath,
                StructureScriptPath = versions.StructureScriptPath,
                AlterScriptPath = versions.AlterScriptPath,
                VersionDescription = versions.VersionDescription
            });
        }
    }
    public class VersionsCommandText : ICommandText
    {
        public string GetById => nameof(Versions) + "_SelectById";
        public string Get => nameof(Versions) + "_Select";
        public string Add => nameof(Versions) + "_Insert";
        public string Update => nameof(Versions) + "_Update";
        public string Delete => nameof(Versions) + "_Delete";
        public string MaxCode => nameof(Versions) + "_MaxCode";

        public string UpdateByKey => nameof(Versions) + "_UpdateByKey";
    }
}
