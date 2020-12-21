using Microsoft.EntityFrameworkCore;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private EduXContext _ctx;
        public CategoriaRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Cria uma categoria
        /// </summary>
        /// <param name="categoria">categoria a ser criada</param>
        public void Adicionar(Categoria categoria)
        {
            try
            {
                _ctx.Categoria.Add(categoria);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma categoria pelo Id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns>categoria</returns>
        public Categoria BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Categoria.FirstOrDefault(c => c.IdCategoria == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita uma categoria ja existente
        /// </summary>
        /// <param name="categoria">categoria a ser editada</param>
        public void Editar(Categoria categoria)
        {
            try
            {

                Categoria categoriaTemp = BuscarPorId(categoria.IdCategoria);


                if (categoriaTemp == null)
                    throw new Exception("Categoria não encontrado");

                //Caso exista, fará a alteração
                categoriaTemp.Tipo = categoria.Tipo;



                _ctx.Categoria.Update(categoriaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista as categorias ja criadas
        /// </summary>
        /// <returns>lista de categorias</returns>
        public List<Categoria> Listar()
        {
            try
            {
                return _ctx.Categoria.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// remove uma categoria pelo seu id
        /// </summary>
        /// <param name="id">id da categoria</param>
        public void Remover(Guid id)
        {
            try
            {

                Categoria categoriaTemp = BuscarPorId(id);

                if (categoriaTemp == null)
                    throw new Exception("categoria não encontrado");


                _ctx.Categoria.Remove(categoriaTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
