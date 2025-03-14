using System.Collections;
using BackendRS.Application.UseCase.ManagerTables;
using BackendSR.Domain.Entities;
using BackendSR.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendRS.Controllers
{
    [ApiController]
    [Route("api/sr")]
    public class ManagerTableController : ControllerBase
    {
        private readonly DataContext _context;

        public ManagerTableController(DataContext context)
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
        public async Task<ActionResult> CreateTable([FromBody] Table table)
        {
            var useCase = new CreateTableUseCase(_context);

            var reponseCreateTable = await useCase.executeCreateTable(table);

            return Created(string.Empty, reponseCreateTable.Value);
        }

        [HttpDelete]
        [Route("deleteTable/{id}")]
        public async Task<ActionResult> DeleteTable(Guid id)
        {
            var useCase = new DeleteTableUseCase(_context);
            var reponseDeleteTable = await useCase.executeDeleteTable(id);
            return Ok(reponseDeleteTable.Value);
        }



    }
}
