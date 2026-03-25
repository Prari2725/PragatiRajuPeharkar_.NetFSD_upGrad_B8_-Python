namespace CRUD.Model
{
    public class Repository
    {
        private List<Employee> e = new List<Employee>();


        public IEnumerable<Employee> E
        {
            get { return e; }
        }

        public void Create(Employee employee)
        {
            e.Add(employee);
        }
    }
}
