using GyfBackendApiDominio.GyfSistemas;
using GyfBackendApiPersistencia.GYFSISTEMAS;


namespace GyfBackendApiPersistencia.SISTEMAS
{
    public class Gyf_SistemasRepository :IGyf_Sistemas
    {
        #region Gyf_SistemasRepository       
        public Gyf_SistemasRepository()
        {
        }
        #endregion
        #region Get_All        
        public async Task<List<GyfSistemaModels>?> Get_All()
        {
            var sistemas = await Task.FromResult(GyfSistemasStore.GyfSistemas_List);
            return sistemas;
        }
        #endregion
        #region Get_One        
        public async Task<GyfSistemaModels?> Get_One(int Id)
        {
            /*
            if (Id == 0)
            {
                _logger.LogError("Error con el parametro id, no puede ser 0");
                return BadRequest();
            }
            var sistema = GyfSistemasStore.GyfSistemasList.FirstOrDefault(s => s.Id == id);
            if (sistema == null)
            {
                _logger.LogError("Error con el parametro id, No existe en la base de datos!");
                return NotFound();
            }*/
            var sistema = await Task.FromResult(GyfSistemasStore.GyfSistemas_List.FirstOrDefault(s => s.Id == Id));
            if (sistema == null)
            {
               // _logger.LogError("Error con el parametro id, No existe en la base de datos!");
                return sistema;
            }
            return sistema;
                
            
        }
        #endregion
        #region Add      

        public Task<bool> Add(GyfSistemaModels entity)
        {
            try
            {
                int Next_Id = GyfSistemasStore.GyfSistemas_List.OrderByDescending(s => s.Id).FirstOrDefault()?.Id + 1 ?? 1;
                entity.Id = Next_Id;

                GyfSistemasStore.GyfSistemas_List.Add(entity);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                // Manejar la excepción o registrarla en un log
                throw new NotImplementedException();
            }
        }
        #endregion
        #region Upd      
        public Task<bool> Upd(GyfSistemaModels entity)
        {
            try
            {
                var sistema = GyfSistemasStore.GyfSistemas_List.FirstOrDefault(s => s.Id == entity.Id);
                if (sistema == null)
                {
                    return Task.FromResult(false);
                }
                sistema.Nombre = entity.Nombre;
                sistema.Descripcion = entity.Descripcion;
                sistema.TipoLicencia = entity.TipoLicencia;
                sistema.Usuario = entity.Usuario;
                GyfSistemasStore.GyfSistemas_List.Remove(sistema);
                GyfSistemasStore.GyfSistemas_List.Add(entity);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                // Manejar la excepción o registrarla en un log

                throw new NotImplementedException();
            }
        }
        #endregion
        #region Del      
        public async Task<bool> Del(int Id)
        {
           
            var sistema = await Task.FromResult(GyfSistemasStore.GyfSistemas_List.FirstOrDefault(s => s.Id == Id));
            if (sistema == null)
            {              
                return false;
            }
             GyfSistemasStore.GyfSistemas_List.Remove(sistema);            
            return true;
        }
        #endregion
    }
}
