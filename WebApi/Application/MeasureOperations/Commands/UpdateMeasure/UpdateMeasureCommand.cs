using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Application.MeasureOperations.Commands.UpdateMeasure
{
    public class UpdateMeasureCommand
    {
        public int MeasureId { get; set; }
        public UpdateMeasureModel Model {get; set;}
        private readonly IOnlineStoreDbContext _context;
        public UpdateMeasureCommand(IOnlineStoreDbContext context)
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
            if(_context.Categories.Any(x => x.Title.ToLower() == Model.MeasureTitle.ToLower() && x.Id != MeasureId))
            {
                throw new InvalidOperationException("This Measure Already Exists.");
            }
            measure.Title=string.IsNullOrEmpty(Model.MeasureTitle.Trim()) ? measure.Title : Model.MeasureTitle;
            measure.IActive =Model.IsActive;
            _context.SaveChanges();
        }
    }
     public class UpdateMeasureModel
     {
        public string MeasureTitle { get; set; }
        public bool IsActive { get; set; } = true;

     }
}