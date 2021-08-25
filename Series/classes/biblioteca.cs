using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series.interfaces;

namespace Series
{
    public class biblioteca : repositorio<series>

    {
        private List<series> listaserie = new List<series>();
        public void atualizar(int id, series entidade)
        {
            listaserie[id] = entidade;
        }

        public void excluir(int id)
        {
            listaserie[id].exclui();
        }

        public void insere(series entidade)
        {
            listaserie.Add(entidade);
        }

        public List<series> lista()
        {
            return listaserie;
        }

        public int proximoid()
        {
            return listaserie.Count;
        }

        public series retornaporid(int id)
        {
            return listaserie[id];
        }


        }

    }
    

     
    

