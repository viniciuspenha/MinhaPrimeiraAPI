using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.infra;
using MinhaPrimeiraAPI.model;

namespace MinhaPrimeiraAPI.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        // CRUD de produtos

        public IActionResult Add([FromBody] ProdutoRequest produtoRequest)
        {
            var produto = produtoRepository.Add(produtoRequest);
            return Ok(produto);
        }

        public IActionResult Update(int id, [FromBody] ProdutoRequest produtoRequest)
        {
            var produto = produtoRepository.Update(id, produtoRequest);
            return produto == null ? NotFound() : Ok(produto);
        }

        public IActionResult GetAll()
        {
            var produtos = produtoRepository.GetAll();
            return Ok(produtos);
        }

        public IActionResult GetById(int id)
        {
            var produto = produtoRepository.Get(id);
            return produto == null ? NotFound() : Ok(produto);
        }

        public IActionResult Delete(int id)
        {
            produtoRepository.Delete(id);
            return Ok();
        }
    }
}
