using Bogus;
using Bogus.Extensions;
using Bogus.Extensions.Brazil;
using Negocios.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FakeData
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var enderecoFake = new Faker<Endereco>("pt_BR")
                .RuleFor(x => x.Bairro, x => x.Address.StreetAddress())
                .RuleFor(x => x.Cep, x => x.Address.ZipCode().Replace("-", ""))
                .RuleFor(x => x.Cidade, x => x.Address.City())
                .RuleFor(x => x.Complemento, x => x.Address.SecondaryAddress())
                .RuleFor(x => x.Numero, x => x.Address.BuildingNumber())
                .RuleFor(x => x.Estado, x => x.Address.State())
                .RuleFor(x => x.Logradouro, x => x.Address.StreetName());

            var produtoFake = new Faker<Produto>("pt_BR")
                .RuleFor(x => x.Nome, x => x.Commerce.Product())
                .RuleFor(x => x.Ativo, x => true)
                .RuleFor(x => x.Descricao, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.Imagem, x => x.Internet.Avatar())
                .RuleFor(x => x.DataCadastro, x => x.Date.Past())
                .RuleFor(x => x.Valor, x => decimal.Parse(x.Commerce.Price()));

            var fornecedorFake = new Faker<Fornecedor>("pt_BR")
                .RuleFor(x => x.Nome, x => x.Company.CompanyName())
                .RuleFor(x => x.Descricao, x => x.Hacker.Phrase())
                .RuleFor(x => x.Documento, x => Regex.Replace(x.Company.Cnpj(), "[^0-9]", ""))
                //.RuleFor(x => x.Endereco, x => enderecoFake)
                .RuleFor(x => x.Ativo, x => true)
                .RuleFor(x => x.TipoFornecedor, x => TipoFornecedor.PessoaJuridica)
                .RuleFor(x => x.Produtos, (x, y) =>
                {
                    produtoFake.RuleFor(x => x.FornecedorId, x => y.Id);

                    var produtos = produtoFake.GenerateBetween(5, 10);

                    return produtos;
                });

            var result = fornecedorFake.GenerateForever();

            var _restClient = new RestClient { BaseUrl = new Uri("https://localhost:5001/api/") };

            foreach (var fornecedor in result)
            {
                var restRequest = new RestRequest("fornecedores", Method.POST, DataFormat.Json);

                restRequest.AddJsonBody(fornecedor);

                var response = await _restClient.ExecuteAsync<bool>(restRequest);

                if (response.Data)
                {
                    Console.WriteLine(response.Content);
                    fornecedor.Dump();
                }

                var content = JsonConvert.SerializeObject(response.Content, Formatting.Indented);

                Console.WriteLine(content);

                await Task.Delay(1000);
            }


        }
    }
}
