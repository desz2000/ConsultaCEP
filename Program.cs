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
        Endereco adress = new Endereco();

        Console.Write("Digite o seu CEP (apenas numeros): ");
        adress.Cep = Console.ReadLine();

        var client = new RestClient("https://viacep.com.br/ws/");
        var request = new RestRequest($"{adress.Cep}/json/", Method.Get);

        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            adress = JsonConvert.DeserializeObject<Endereco>(response.Content);
            Console.WriteLine($"Aqui esta o seu endereço: {adress.Logradouro}, {adress.Bairro}, {adress.Localidade} - {adress.Uf}");
            //Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine($"Erro: {response.ErrorMessage}");
        }
    }
}