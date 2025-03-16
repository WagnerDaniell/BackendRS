using System.Collections;
using BackendRS.Application.UseCase.ManagerTables;
using BackendRS.Domain.Entities;
using BackendRS.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendRS.Controllers
{
    [ApiController]
    [Route("api/sr")]
    public class TablesController : ControllerBase
    {
        private readonly DataContext _context;

        public TablesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("seetables")]
        public async Task<ActionResult<IEnumerable<Table>>> SeeTables()
        {
            var result = await _context.Tables.ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        [Route("createTable")]
        public async Task<ActionResult> CreateTable([FromBody] Table table, string token)
        {
            var useCase = new CreateTableUseCase(_context);

            var reponseCreateTable = await useCase.executeCreateTable(table, token);

            return Created(string.Empty, reponseCreateTable.Value);
        }

        [HttpDelete]
        [Route("deleteTable/{id}")]
        public async Task<ActionResult> DeleteTable(Guid id, string token)
        {
            var useCase = new DeleteTableUseCase(_context);
            var reponseDeleteTable = await useCase.executeDeleteTable(id, token);
            return Ok(reponseDeleteTable.Value);
        }

        [HttpPatch]
        [Route("updateTable/{id}")]
        public async Task<ActionResult> UpdateTable(Guid id, [FromBody] Table table)
        {
            var useCase = new UpdateTablesUseCase(_context);
            var reponseUpdateTable = await useCase.executeUpdate(id, table.Name, table.Status, table.Capacity);
            return Ok(reponseUpdateTable.Value);
        }
    }   
}
