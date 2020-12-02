
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Interfaces;
using ProjetoEduX.Utils;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Repositories
{
    public class DicaRepository : IDicaRepository
    {
        private readonly EduXContext _ctx = new EduXContext();
        public void Adicionar(Dica dica)
        {
            try
            {
              
                _ctx.Dica.Add(dica);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Dica BuscarPorId(Guid id)
        {

            try
            {
                return _ctx.Dica.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }

        }

        public void Editar(Dica dica)
        {
            {
                try
                {
                    Dica dicaTemp = BuscarPorId(dica.IdDica);

                    if (dicaTemp == null)
                        throw new Exception("Dica não encontrada.");

                    _ctx.Dica.Update(dicaTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); ;
                }
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                Dica dica = BuscarPorId(id);

                if (dica == null)
                    throw new Exception("Dica não encontrada");

                _ctx.Dica.Remove(dica);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        public List<Dica> Listar()
        {
            try
            {
                List<Dica> Dica = _ctx.Dica.ToList();
                return Dica;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}