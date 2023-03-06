using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.MeasureOperations.Queries.GetMeasureDetail
{
    public class GetMeasureDetailQuery
    {
         public int MeasureId { get; set; }
        public readonly IOnlineStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetMeasureDetailQuery(IOnlineStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public MeasureDetailViewModel Handle()
        {
            var measure = _contex.Measures.Where(x => x.IActive && x.Id == MeasureId ).SingleOrDefault();
            if(measure is null)
            {
                throw new InvalidOperationException("Measure not found.");
            }
            MeasureDetailViewModel vm= _mapper.Map<MeasureDetailViewModel>(measure);

            return vm;
        }
    }
    public class MeasureDetailViewModel
    {
        public string Title { get; set; }
        
    }
}