namespace EfCore.CodeFirst.DAL
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }

        public List<Student> Students { get; set; }
    }
}
