using ProjetoEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Interfaces
{
    interface ICategoriaRepository
    {
        /// <summary>
        /// Lista todos os categorias
        /// </summary>
        /// <returns>Todos os categorias</returns>
        List<Categoria> Listar();
        /// <summary>
        /// Busca um categoria através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O categoria solicitado pelo Id</returns>
        Categoria BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um categoria
        /// </summary>
        /// <param name="categoria"></param>
        void Adicionar(Categoria categoria);
        /// <summary>
        /// Edita um dado de categoria
        /// </summary>
        /// <param name="categoria"></param>
        void Editar(Categoria categoria);
        /// <summary>
        /// Remove um categoria
        /// </summary>
        /// <param name="id"></param>
        void Remover(Guid id);
    }
}
