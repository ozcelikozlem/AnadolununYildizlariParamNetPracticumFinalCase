using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.MeasureOperations.Commands.DeleteMeasure
{
    public class DeleteMeasureCommand
    {
        public int MeasureId { get; set; }
        private readonly IOnlineStoreDbContext _context;
        public DeleteMeasureCommand(IOnlineStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var measure = _context.Measures.SingleOrDefault(x=> x.Id == MeasureId);
            if(measure is null)
            {
                throw new InvalidOperationException("Measure not found.");
            }
            _context.Measures.Remove(measure);
            _context.SaveChanges();
        }
    }
}