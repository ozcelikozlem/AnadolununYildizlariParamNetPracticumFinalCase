using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.MeasureOperations.Queries.GetMeasures
{
    public class GetMeasuresQuery
    {
        public readonly IOnlineStoreDbContext _contex;
        public readonly IMapper _mapper;
        public GetMeasuresQuery(IOnlineStoreDbContext contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public List<MeasuresViewModel> Handle()
        {
            var measures = _contex.Measures.Where(x => x.IActive).OrderBy(x => x.Id);
            List<MeasuresViewModel> returnObj = _mapper.Map<List<MeasuresViewModel>>(measures);
            return returnObj;
        }
    }

    public class MeasuresViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}