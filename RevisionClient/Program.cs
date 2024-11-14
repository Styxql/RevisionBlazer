using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RevisionClient.Services;
using RevisionClient.ViewModels;

namespace RevisionClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddSingleton(ws => new WSService("https://localhost:7177/api/"));
            builder.Services.AddScoped<ViewModel>();
            await builder.Build().RunAsync();

        }
    }
}
