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

        string? resposta = "s";

        while(resposta == "s")
        {
            services.ConsultaEndereco();

            Console.WriteLine("Gostaria de pesquisar outro CEP? s/n");
            resposta = Console.ReadLine();
        }
        Console.WriteLine("\nFim da pesquisa :)");
    }
}