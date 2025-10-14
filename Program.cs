using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace ConsultaCep;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Hora de descobrir seu endereço!");

        Services services = new Services();
        Endereco adress = new Endereco();

        string? resposta = "s";

        while(resposta == "s")
        {
            Console.Write("Digite o seu CEP (apenas numeros): ");
            adress.Cep = Console.ReadLine();
            
            string enderecoRetorno = services.ConsultaEndereco(adress);
            Console.WriteLine(enderecoRetorno);


            Console.WriteLine("Gostaria de pesquisar outro CEP? s/n");
            resposta = Console.ReadLine();
        }
        Console.WriteLine("Fim da pesquisa :)");
    }
}