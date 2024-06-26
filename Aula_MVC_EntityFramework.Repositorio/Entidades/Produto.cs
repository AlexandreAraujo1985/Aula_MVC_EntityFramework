﻿using System.ComponentModel.DataAnnotations;

namespace Aula_MVC_EntityFramework.Repositorio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public IEnumerable<ProdutoEmPromocao> ProdutosEmPromocao { get; set; }
    }
}
