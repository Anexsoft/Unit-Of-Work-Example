using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using UnitOfWorkPersistence;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        void DetectChanges();
        void SaveChanges();
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();

        IUnitOfWorkRepository Repository { get; }
    }

    public class UnitOfWorkContainer : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUnitOfWorkRepository Repository { get; }

        public UnitOfWorkContainer(
            ApplicationDbContext context
        )
        {
            _context = context;
            Repository = new UnitOfWorkRepository(_context);
        }

        #region Detect Changes
        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }
        #endregion

        #region Save Changes
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Transactions
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
        #endregion
    }
}
