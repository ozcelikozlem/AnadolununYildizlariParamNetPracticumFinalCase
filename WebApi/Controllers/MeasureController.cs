using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MeasureOperations.Commands.CreateMeasure;
using WebApi.Application.MeasureOperations.Commands.DeleteMeasure;
using WebApi.Application.MeasureOperations.Commands.UpdateMeasure;
using WebApi.Application.MeasureOperations.Queries.GetMeasureDetail;
using WebApi.Application.MeasureOperations.Queries.GetMeasures;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize(Roles ="Administrator")]
    [ApiController]
    [Route("[controller]s")]
    public class MeasureController : ControllerBase
    {
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;

        public MeasureController(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetMeasures()
        {
            GetMeasuresQuery query = new GetMeasuresQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public ActionResult GetMeasureDetail(int id)
        {
            GetMeasureDetailQuery query = new GetMeasureDetailQuery(_context,_mapper);
            query.MeasureId =id;
            GetMeasureDetailQueryValidator validator = new GetMeasureDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }
        
        [HttpPost]
        public IActionResult AddMeasure([FromBody] CreateMeasureModel newCategory)
        {
            CreateMeasureCommand command = new CreateMeasureCommand(_context,_mapper);
            command.Model=newCategory;

            CreateMeasureCommandValidator validator = new CreateMeasureCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateMeasure(int id, [FromBody] UpdateMeasureModel updateMeasure)
        {
            UpdateMeasureCommand command = new UpdateMeasureCommand(_context);
            command.MeasureId=id;
            command.Model = updateMeasure;

            UpdateMeasureCommandValidator validator = new UpdateMeasureCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            DeleteMeasureCommand command = new DeleteMeasureCommand(_context);
            command.MeasureId=id;

            DeleteMeasureCommandValidator validator = new DeleteMeasureCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}