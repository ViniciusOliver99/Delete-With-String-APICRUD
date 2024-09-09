using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace TeachersAPI.Domain.Model
{
    [Table("teachers")]
    public class Teachers
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }    
        public int age { get; set; }
        public bool active { get; set; }

        public Teachers(string name, int age)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.age = age;
            this.active = true;
        }

        public void Up(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
