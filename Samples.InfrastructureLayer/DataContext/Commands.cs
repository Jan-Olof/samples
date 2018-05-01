using AutoMapper;
using System;

namespace Samples.InfrastructureLayer.DataContext
{
    public abstract class Commands
    {
        protected readonly SampleContext Context;
        protected readonly IMapper Mapper;

        protected Commands(SampleContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}