// ReSharper disable MemberCanBePrivate.Global
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Samples.WebApi
{
    /// <summary>
    /// The starting class of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Build web host.
        /// </summary>
        public static IWebHost BuildWebHost(string[] args)
            => WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

        /// <summary>
        /// The starting point of the application.
        /// </summary>
        public static void Main(string[] args)
            => BuildWebHost(args).Run();
    }
}