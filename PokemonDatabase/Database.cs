using FluentMigrator.Runner;
using FluentNHibernate.Conventions.Helpers.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace PokemonDatabase.API
{
    public class Database
    {
        private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=PokemonDatabase;TrustServerCertificate=True;Integrated Security=SSPI";

        public static void RunMigrations()
        {
            var serviceProvider = CreateServices();

            using (var scope = serviceProvider.CreateScope())
            {
                RunMigrations(scope.ServiceProvider);
            }
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(ConnectionString)
                    .ScanIn(typeof(Database).Assembly).For.Migrations()
                )
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider();
        }

        private static void RunMigrations(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

    }
}
