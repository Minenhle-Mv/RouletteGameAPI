using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using RouletteGameAPI.Models;
using RouletteGameAPI.Repositories;

namespace RouletteGameAPI.Repositories
{
    public class PreviousSpinRepository : IPreviousSpinRepository
    {
        private readonly IConfiguration _config;


        public PreviousSpinRepository(IConfiguration config)
        {
            _config = config;
        }


        public Task<IEnumerable<PreviousSpinResponse>> ShowPreviousSpins()
        {
            using var connection = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
            var PreviousSpins =  connection.QueryAsync<PreviousSpinResponse>("select * from Spin");
            return PreviousSpins;
            
        }


    }
}
