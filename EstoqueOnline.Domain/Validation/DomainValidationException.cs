using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueOnline.Domain.Validation
{
    public class DomainValidationException:Exception
    {
        public DomainValidationException(string error):base(error) { }
        public static void When (bool condition, string error)
        {
            if (condition)
                throw new DomainValidationException(error);
        }
    }
}
