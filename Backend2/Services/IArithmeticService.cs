using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend2.Services
{
   public interface IArithmeticService
    {
        int sum(int a, int b);
        int del(int a, int b);
        int minus(int a, int b);
        int plus(int a, int b);

    }
}
