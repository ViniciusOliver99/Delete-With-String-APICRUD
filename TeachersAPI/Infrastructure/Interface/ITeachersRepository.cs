using TeachersAPI.Domain.Model;

namespace TeachersAPI.Infrastructure.Interface
{
    public interface ITeachersRepository
    {
        List<Teachers> GetAll();
        Teachers GetById(Guid id);
        void Add(Teachers teachers);
        void Update(Teachers teachers);
        void Delete(string name);
    }
}
