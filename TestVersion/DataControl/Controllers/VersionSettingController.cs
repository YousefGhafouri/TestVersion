using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVersion.DataAccess.Repositories;
using TestVersion.Entities;
using TestVersion.Model;
using TestVersion.Utilities;
using static TestVersion.Utilities.DataStructure;

namespace TestVersion.DataControl.Controllers
{
    public class VersionSettingController : IController<VersionSetting, VersionSettingDto>
    {
        ICommandText commandText;
        private Repository<VersionSetting> repository;
        public VersionSettingController()
        {
            commandText = new VersionSettingCommandText();
            repository = new Repository<VersionSetting>(/*configuration,*/ commandText);
        }
        public VersionSetting Add(VersionSettingDto versionSetting)
        {
            return repository.Add(GetAddParameter(versionSetting));
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

        public List<VersionSettingDto> GetAll()
        {
            return repository.Get().ToXList<VersionSetting, VersionSettingDto>();
        }

        public VersionSettingDto GetById(int id)
        {
            return repository.GetById(id).ToDto<VersionSetting, VersionSettingDto>();
        }

        public VersionSetting Save(DataStructure.FormAction formAction, VersionSettingDto versionSetting)
        {
            if (formAction == FormAction.Add)
                return Add(versionSetting);
            else
            {
                Update(versionSetting);
                return null;
            }
        }

        public void SaveList(DataStructure.FormAction formAction, List<VersionSettingDto> versionSetting)
        {
            if (formAction == FormAction.Add)
                foreach (VersionSettingDto item in versionSetting)
                {
                    Add(item);
                }
            else
            {
                foreach (var item in versionSetting)
                {
                    UpdateByKey(item);
                }
            }
        }

        public void Update(VersionSettingDto versionSetting)
        {
            repository.Update(GetUpdateParameter(versionSetting));
        }

        public void UpdateByKey(VersionSettingDto versionSetting)
        {
            repository.UpdateByKey(GetUpdateByKeyParameter(versionSetting));
        }

        internal DynamicParameters GetAddParameter(VersionSettingDto versionSetting)
        {
            return new DynamicParameters(new
            {
                SettingKey = versionSetting.SettingKey,
                SettingValue = versionSetting.SettingValue,
                SettingDescription = versionSetting.SettingDescription
            }) ;
        }

        internal DynamicParameters GetUpdateParameter(VersionSettingDto versionSetting)
        {
            return new DynamicParameters(new
            {
                ID = versionSetting.ID,
                SettingKey = versionSetting.SettingKey,
                SettingValue = versionSetting.SettingValue,
                SettingDescription = versionSetting.SettingDescription
            });
        }

        internal DynamicParameters GetUpdateByKeyParameter(VersionSettingDto versionSetting)
        {
            return new DynamicParameters(new
            {
                SettingKey = versionSetting.SettingKey,
                SettingValue = versionSetting.SettingValue
            });
        }
    }

    public class VersionSettingCommandText : ICommandText
    {
        public string GetById => nameof(VersionSetting) + "_SelectById";

        public string Get => nameof(VersionSetting) + "_Select";

        public string Add => nameof(VersionSetting) + "_Insert";

        public string Update => nameof(VersionSetting) + "_Update";

        public string UpdateByKey => nameof(VersionSetting) + "_UpdateByKey";

        public string Delete => nameof(VersionSetting) + "_Delete";

        public string MaxCode => nameof(VersionSetting) + "_MaxCode";

        public string GetByKey => nameof(VersionSetting) + "SelectByKey";
    }
}
