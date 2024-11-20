using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.domain;
using MinhaPrimeiraAPI.model;

namespace MinhaPrimeiraAPI.controller
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        // CRUD de produtos

        [HttpPost]
        public IActionResult Add([FromBody] ProdutoRequest produtoRequest)
        {
            var produto = produtoRepository.Add(produtoRequest);
            return Ok(produto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] ProdutoRequest produtoRequest)
        {
            var produto = produtoRepository.Update(id, produtoRequest);
            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = produtoRepository.GetAll();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = produtoRepository.Get(id);
            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            produtoRepository.Delete(id);
            return Ok();
        }
    }
}
