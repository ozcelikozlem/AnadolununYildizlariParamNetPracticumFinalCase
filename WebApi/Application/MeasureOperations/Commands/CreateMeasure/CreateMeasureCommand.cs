using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MeasureOperations.Commands.CreateMeasure
{
    public class CreateMeasureCommand
    {
        public CreateMeasureModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMeasureCommand(IOnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var measure = _context.Measures.SingleOrDefault(x=> x.Title == Model.Title);
            if(measure is not null)
            {
                throw new InvalidOperationException("Measure already exists.");
            }

            measure = _mapper.Map<Measure>(Model);

            _context.Measures.Add(measure);
            _context.SaveChanges();
        }
    }
    public class CreateMeasureModel
    {
        public string Title { get; set; }
    }
}