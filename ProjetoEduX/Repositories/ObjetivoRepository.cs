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
    public class ObjetivoRepository : IObjetivoRepository
    {

        private EduXContext _ctx;
        public ObjetivoRepository()
        {
            _ctx = new EduXContext();
        }

        /// <summary>
        /// Cria uma objetivo
        /// </summary>
        /// <param name="objetivo">objetivo a ser criado</param>
        public void Adicionar(Objetivo objetivo)
        {
            try
            {
                _ctx.Objetivo.Add(objetivo);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma objetivo pelo Id
        /// </summary>
        /// <param name="id">Id da objetivo</param>
        /// <returns>objetivo</returns>
        public Objetivo BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Objetivo.FirstOrDefault(c => c.IdObjetivo == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita uma objetivo ja existente
        /// </summary>
        /// <param name="objetivo">objetivo a ser editada</param>
        public void Editar(Objetivo objetivo)
        {
            try
            {

                Objetivo objetivoTemp = BuscarPorId(objetivo.IdObjetivo);


                if (objetivoTemp == null)
                    throw new Exception("Objetivo não encontrado");

                //Caso exista, fará a alteração
                objetivoTemp.Descricao = objetivo.Descricao;



                _ctx.Objetivo.Update(objetivoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista as objetivos ja criadas
        /// </summary>
        /// <returns>lista de objetivos</returns>
        public List<Objetivo> Listar()
        {

            try
            {
                return _ctx.Objetivo.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
            


        /// <summary>
        /// remove uma objetivo pelo seu id
        /// </summary>
        /// <param name="id">id da objetivo</param>
        public void Remover(Guid id)
        {
            try
            {

                Objetivo objetivoTemp = BuscarPorId(id);

                if (objetivoTemp == null)
                    throw new Exception("objetivo não encontrado");


                _ctx.Objetivo.Remove(objetivoTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
