using Samples.ApplicationLayer;
using System;

namespace Samples.InfrastructureLayer.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleContext _context;

        public UnitOfWork(SampleContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <inheritdoc />
        public int Store() => _context.SaveChanges();
    }
}