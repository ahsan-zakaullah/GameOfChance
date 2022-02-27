using GameOfChance.API;
using GameOfChance.Repository.DbContexts.PlayerDbContext;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;

namespace GameOfChance.Api.Test.Integration.Infrastructure
{
    public class IntegrationTestFixture : IDisposable
    {
        public readonly IPlayerDbContext? DbContext;
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTestFixture()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            DbContext = _factory.Services.GetService(typeof(IPlayerDbContext)) as IPlayerDbContext;
        }
        public void Dispose()
        {
            DbContext?.Dispose();
            _factory.Dispose();
        }

        public HttpClient HttpClient => _factory.CreateClient();
    }
}
