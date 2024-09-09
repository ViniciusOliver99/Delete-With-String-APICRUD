using TeachersAPI.Domain.Model;
using TeachersAPI.Infrastructure.Interface;

namespace TeachersAPI.Infrastructure.Repositories
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Teachers teachers)
        {
            _context.teachers.Add(teachers);
            _context.SaveChanges();
        }

        public void Delete(string name)
        {
            var teachers = _context.teachers.FirstOrDefault(t => t.name == name);
            _context.teachers.Remove(teachers);
            _context.SaveChanges();
        }

        public List<Teachers> GetAll()
        {
            return _context.teachers.ToList();
        }

        public Teachers GetById(Guid id)
        {
            return _context.teachers.Find(id);
        }

        public void Update(Teachers teachers)
        {
            var TeachersId = _context.teachers.Find(teachers.id);

            TeachersId.Up(teachers.name, teachers.age);
            _context.SaveChanges();
        }
    }
}
