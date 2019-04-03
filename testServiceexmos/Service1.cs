using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;

namespace testServiceexmos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        Boolean IsNegativeBalance = false;
        string Address;
        string Name;
        int AccountID;

        //public double money { get; set; }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public double balance(double? NewBalancexx)
        {
            if(NewBalancexx != null)
            {
                return 250.00;
            } else
            {
                return Convert.ToDouble(NewBalancexx);
            }
            
        }

        [WebMethod]
        public static bool AddPayment(int AccountID, double money, double Balancex)
        {
            Service1 s = new Service1();
            if((s.balance(Balancex) - money) <= 0)
            {
                s.IsNegativeBalance = true;
            } else
            {
                s.IsNegativeBalance = false;
            }

            return s.IsNegativeBalance;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
