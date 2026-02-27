using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnArray.Interface.Patterns
{
    public interface IVisitor : IPattern
    {
        void Visit(object value);
    }
}
