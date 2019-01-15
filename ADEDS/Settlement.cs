using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADEDS
{
    public class Settlement
    {
        private ISettlementType settlementType;

        public Settlement(string type)
        {
            if (type == "invoice")
                settlementType = new Invoice();
            else
                settlementType = new Receipt();
        }
        public void printSettlement()
        {
            settlementType.createSettlement();
        }
    }
    public interface ISettlementType
    {
        string createSettlement();
    }
    public class Invoice : ISettlementType
    {
        
        public string createSettlement()
        {
            return "a";
        }
    }
    public class Receipt : ISettlementType
    {

        public string createSettlement()
        {
            return "b";
        }
    }

}
