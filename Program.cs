using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace your_first_blazor
{
    public class Program
    {
    public static async Task Main(string[] args)
    {
        // 
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        
        // 注册根组件
        builder.RootComponents.Add<App>("#app");

        // 注册 HttpClient 服务
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // 注册 ant design 服务
        builder.Services.AddAntDesign();

        await builder.Build().RunAsync();
    }
    }
}
