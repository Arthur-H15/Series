using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series;

namespace Series.interfaces
{
    public interface repositorio<T>
    {
        List<T> lista();
        T retornaporid(int id);
        void insere(T entidade);
        void excluir(int id);
        void atualizar(int id, T entidade);
        int proximoid();
       
        

    }
}
