using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVersion.Utilities;

namespace Updater.DataControl.Controllers
{
    public interface IController<TEntity, TDto> : IDisposable
    {
        TEntity Add(TDto ReportColumn);
        void Delete(int id);
        List<TDto> GetAll();
        TDto GetById(int id);
        TEntity Save(DataStructure.FormAction formAction, TDto reportColumn);
        void Update(TDto ReportColumn);
    }
}
