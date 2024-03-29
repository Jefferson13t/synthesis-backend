using Synthesis.Domain.DTOs;

namespace Synthesis.Model
{
    public interface IColumnRepository{
        void Add(Column column);
        List<ColumnDTO> Get();
        Column GetById(string Id);
        void Update(Column Column);
        void Delete(string Id);
    }
}