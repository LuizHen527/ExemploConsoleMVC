using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprendendoMVC.Model;
using AprendendoMVC.View;

namespace AprendendoMVC.Controller
{
    public class ProdutoController
    {
        //Instanciar objeto produto e produtoView

        Produto produto = new Produto();
        ProdutoView produtoView = new ProdutoView();

        //metodo controlador para acessar a listagem de produtos
        public void ListarProdutos()
        {
            //lista de produtos chamada pela model
            List<Produto> produtos = produto.Ler();

            //Chamada do metodo de exibicao(VIEW) recebendo como argumento a lista
            produtoView.Listar(produtos);
        }

        //Metodo controlador para acessar o cdastro de produto

        public void CadastrarProduto()
        {
            //Chamada para a view que recebe cada objeto a ser incerido no csv
            Produto novoProduto = produtoView.Cadastrar();

            //chamada para a model para incerir esse objeto no csv
            produto.Inserir(novoProduto);
        }
    }
}