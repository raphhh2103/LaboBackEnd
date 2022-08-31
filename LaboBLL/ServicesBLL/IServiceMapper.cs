using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboBLL.ServicesBLL
{
    public interface IServiceMapper<Tmodels>
    {
        public Tmodels Create(Tmodels entity);
        public Tmodels Update(Tmodels entity);
        public Tmodels GetOne(string str);
        public IEnumerable<Tmodels> GetAll();
        public Tmodels Delete(string str);
    }
}
