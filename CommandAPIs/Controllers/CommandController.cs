using System;
using System.Collections.Generic;
using CommandAPIs.Data;
using CommandAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommandAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CommandController(AppDbContext context) => _context = context;

        //GET:              /api/Command
        [HttpGet]
        public ActionResult<IEnumerable<Commands>> GetCommands()
        {
            return _context.Commands;
        }

        //GET:              /api/Command/Id
        [HttpGet("{Id}")]
        public ActionResult<Commands> GetCommandById(int Id)
        {
            var commandById = _context.Commands.Find(Id);

            if (commandById == null)
            {
                return NotFound();
            }

            return commandById;
        }
        
        //POST:             /api/Command
        [HttpPost]
        public ActionResult<Commands> PostCommand(Commands command)
        {
            _context.Commands.Add(command);
            _context.SaveChanges();
            return CreatedAtAction("GetCommandById", new Commands {Id = command.Id},command);
        }
        
        //DELETE:           /api/Command/Id
        [HttpDelete("{Id}")]
        public ActionResult<Commands> DeleteCommandById(int Id)
        {
            var command = _context.Commands.Find(Id);
            _context.Remove(command);
            _context.SaveChanges();
            return command;
        }
        
        //PUT:              /api/Command/Id
        [HttpPut]
        public ActionResult UpdateCommandById(int Id, Commands command)
        {
            if (Id != command.Id)
                return BadRequest("Id mismatch");

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        
    }
}