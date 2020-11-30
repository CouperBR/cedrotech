using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IRestauranteService
    {
        List<restaurante> Get(string nome = "");
        restaurante Get(int id);
        void Save(restaurante prato);
        void Update(int id, restaurante prato);
        void Delete(int id);
    }
}
