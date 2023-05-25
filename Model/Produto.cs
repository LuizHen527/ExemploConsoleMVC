using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AprendendoMVC.Model
{
    public class Produto
    {
        //propriedades
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        //Caminho da pasta e do arquivo definido
        private const string PATH = "Database/Produto.csv";

        public Produto()
        {
            //obter o caminho da pasta
            string pasta = PATH.Split("/")[0]; //"Database"

            //Se nao existir uma pasta Database, entao cria-se uma
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            //Se nao existir um arquivo csv no caminho, entao cria-se um
            if(!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        public List<Produto> Ler()
        {
            //Instanciar uma lista de produtos
            List<Produto> produtos = new List<Produto>();

            //Array de string que recebe cada linha do csv
            string[] linhas = File.ReadAllLines(PATH);

            //Para a leitura das linhas
            foreach (var item in linhas)
            {
                //antes do split 
                //001;Coca;6,50

                //Array que recebe os itens da linha separado por ";"
                string[] atributos = item.Split(";");

                //apos o Split
                //atributo[0] = "001"
                //atributo[1] = "Coca"
                //atributo[2] = "6,50"

                //Instancia de objeto produto
                Produto p = new Produto();

                //Atribuir os dados dentro de um objeto
                p.Codigo = int.Parse(atributos[0]);//001
                p.Nome = atributos[1];//"Coca"
                p.Preco = float.Parse(atributos[2]);//6,50

                //adiciona os objetos dentro da lista
                produtos.Add(p);
            }
        //retorna a lista de produtos
        return produtos;
        }

        //Metodo para preparar linha do csv

        public string PrepararLinhasCSV(Produto p)
        {
            return $"{p.Codigo};{p.Nome};{p.Preco}";
        }

        //Metodo para inserir um produto no arquivo csv

        public void Inserir(Produto p)
        {
            //Array que vai armazenar as linhas(cada "objeto")
            string[] linhas = {PrepararLinhasCSV(p)};

            //Vai ate o arquivo e insere todas as linhas
            File.AppendAllLines(PATH, linhas);
        }
    }
}