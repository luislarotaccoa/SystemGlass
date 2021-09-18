using System.Collections.Generic;

namespace LOGICA.Logica
{
    public interface IRepositorio<Model> where Model:class
    {
        Model Consulta(int id);
        List<Model> Listar(object f1, object f2);
        List<Model> Buscar(List<Model> list, string dato);
        string Modificar(Model entity);
        string Registrar(Model entity);
        string Eliminar(int Id, bool act);
    }
}
