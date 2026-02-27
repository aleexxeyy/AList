using System.Collections.Generic;

namespace LearnArray.Interface.Dao
{
    public interface IDao
    {
        public int Create(Person person);
        public List<Person> Read();
        public void Update(Person person);
        public void Delete(Person person);
    }
}
