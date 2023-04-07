using GyfBackendApiDominio.GyfSistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyfBackendApiPersistencia.SISTEMAS
{
    public interface IGyf_Sistemas
    {
        //Traer la Lista con todos los Sistemas
        Task<List<GyfSistemaModels>?> Get_All();
        //Consultar un sistema por Id 
        Task<GyfSistemaModels?> Get_One(int Id);
        //Agregar un nuevo sistema a lista
        Task<bool> Add(GyfSistemaModels entity);
        //Actualizar un sistema 
        Task<bool> Upd(GyfSistemaModels entity);
        //Borrar un sistema de la lista
        Task<bool> Del(int Id);
    }
}
