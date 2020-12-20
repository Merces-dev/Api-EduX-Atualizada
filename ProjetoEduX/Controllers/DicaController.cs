using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEdux.Repositories;
using ProjetoEduX.Contexts;
using ProjetoEduX.Domains;
using ProjetoEduX.Utils;

namespace ProjetoEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private readonly DicaRepository _dicaRepository;

        public DicaController()
        {
            _dicaRepository = new DicaRepository();
        }

        /// <summary>
        /// Lista todos itens do Objeto Dicas
        /// </summary>
        /// <returns>Dica Categoria</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dicas = _dicaRepository.Listar();

                if (dicas.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = dicas.Count,
                    data = dicas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/Usuarios"
                });
            }
        }

        /// <summary>
        /// Busca Objeto Dica por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dica Buscada</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Dica dica = _dicaRepository.BuscarPorId(id);

                if (dica == null)
                    return NotFound();

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita Objeto dica
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dica"></param>
        /// <returns>Itens dica a serem editados</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Dica Dica)
        {
            try
            {
                Dica.IdDica = id;
                //Edita a Curso
                _dicaRepository.Editar(Dica);

                //Retorna Ok com os dados da Curso
                return Ok(Dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona Objeto Dica
        /// </summary>
        /// <param name="dica"></param>
        /// <returns>Objeto dica a ser adicionado</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Dica Dica)
        {
            try
            {
                if (Dica.Imagem != null)
                {
                    var urlImagem = Upload.Local(Dica.Imagem);
                    Dica.UrlImagem = urlImagem;
                }
                _dicaRepository.Adicionar(Dica);

                return Ok(Dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Exclui Objeto Dica
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto dica a ser Excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var Dica = _dicaRepository.BuscarPorId(id);


                if (Dica == null)
                    return NotFound();


                _dicaRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}