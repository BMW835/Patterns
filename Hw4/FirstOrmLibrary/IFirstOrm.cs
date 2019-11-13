using Hw4.Models.Interfaces;

namespace Hw4.FirstOrmLibrary
{
    public interface IFirstOrm<TDbEntity> where TDbEntity : IDbEntity
    {
        void Add(TDbEntity entity);
        TDbEntity Read(int id);
        void Delete(TDbEntity entity);
    }
}