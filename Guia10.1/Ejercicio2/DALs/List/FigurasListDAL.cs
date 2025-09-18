using Ejercicio.Models;
namespace Ejercicio.DALs.List;

public class FigurasListDAL:IFigurasDAL
{
    int id = 1;
    List<FiguraModel> figuras = new List<FiguraModel>();

    async public Task<List<FiguraModel>> GetAll()
    {
        return await Task.FromResult(figuras);
    }

    async public Task<FiguraModel> GetById(int idFigura)
    {
        FiguraModel figura = (from f in figuras where f.Id == idFigura select f).FirstOrDefault();
        return await Task.FromResult(figura);
    }
    
    async public Task<FiguraModel> Add(FiguraModel nuevo)
    {
        FiguraModel f = await GetById(nuevo.Id ?? 0);

        if (f == null)
        {
            figuras.Add(nuevo);
            nuevo.Id = id++; 
            return nuevo;
        }
        return null;
    }

    async public Task<bool> Save(FiguraModel entidad)
    {
        FiguraModel f = await GetById(entidad.Id??0);

        if (f==null)
        {
            figuras.Add(entidad);
            return true;
        }
        return false;
    }

    async public Task<bool> Remove(int idFigura)
    {
        FiguraModel f = await GetById(idFigura);

        if (f != null)
        {
            figuras.Remove(f);
            return true;
        }

        return false;
    }
}
