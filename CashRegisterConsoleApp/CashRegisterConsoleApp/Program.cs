using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.BLL;
using CashRegister.BO;
using CashRegister.Utility;

namespace CashRegisterConsoleApp
{
    class Program
    {
        // Calling BLL from the UI

        public static void Main(string[] args)
        {
        
        BusinessManager businessMananger = new BusinessManager();
        businessMananger.DotheWork();
        }
    }
}
