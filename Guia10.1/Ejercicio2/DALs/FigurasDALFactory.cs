
using Ejercicio.DALs.List;
using Ejercicio.DALs.MSQL;

namespace Ejercicio.DALs;

static public class FigurasDALFactory
{
    static public IFigurasDAL CrearDao(TipoDAL tipo)
    {
        switch (tipo)
        { 
            case TipoDAL.MSQL:
                return new FigurasMSQLDAL();

            case TipoDAL.List:
                return new FigurasListDAL();
        }
        return null;
    }


}


