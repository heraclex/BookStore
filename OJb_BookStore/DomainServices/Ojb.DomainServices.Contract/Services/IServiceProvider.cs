using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aswig.DomainServices.Contract.Services
{
    public interface IServiceProvider
    {
        IAccountService GetService();

        bool AddDataTest(int x);

        int TestData(int x);

        int ExecSum(int x, int y);
    }
}
