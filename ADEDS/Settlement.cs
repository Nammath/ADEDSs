using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public void printSettlement(List<ModelItem> list)
        {
            settlementType.createSettlement(list);
        }
        public void changeType()
        {
            if (settlementType is Invoice)
            {
                settlementType = new Receipt();
            }
            else
            {
                settlementType = new Invoice();
            }
                
        }
    }
    public interface ISettlementType
    {
        string createSettlement(List<ModelItem> list);
        
    }
    public class Invoice : ISettlementType
    {
        
        public string createSettlement(List<ModelItem> list)
        {
            MessageBox.Show("Invoice");
            return "a";
        }
    }
    public class Receipt : ISettlementType
    {

        public string createSettlement(List<ModelItem> list)
        {
            MessageBox.Show("Receipt");
            return "b";
        }
    }

}
