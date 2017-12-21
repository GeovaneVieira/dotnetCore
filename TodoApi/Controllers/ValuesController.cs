using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devart.Data.Oracle;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using Dapper;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<Aluno>> ObterAlunos()
        {
            string oracleConnectionString = "User ID=SLounge; Password=SloungeAdmin; Direct=true; Host=172.31.42.239; Service Name=xe; Port=1521;";

            using (var conn = new OracleConnection(oracleConnectionString))
            {

                conn.Open();
                IEnumerable<Aluno> lista = new List<Aluno>();
                lista = await conn.QueryAsync<Aluno>("SELECT Id, NOME, NOME_MEIO, SOBRENOME  FROM SL_ALUNO");

                return lista.ToList();
            }
        }
    }
}
