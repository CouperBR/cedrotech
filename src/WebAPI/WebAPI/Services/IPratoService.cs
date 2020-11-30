using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IPratoService
    {
        List<prato> Get(string nome = "");
        prato Get(int id);
        void Save(prato prato);
        void Update(int id, prato prato);
        void Delete(int id);
    }
}
