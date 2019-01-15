using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
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
        public void printSettlement(List<ModelItem> list, string name, string phone, string address)
        {
            settlementType.createSettlement(list, name, phone, address);
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
        string createSettlement(List<ModelItem> list, string name, string phone, string address);
        
    }
    public class Invoice : ISettlementType
    {
        
        public string createSettlement(List<ModelItem> list, string name, string phone, string address)
        {
            var pdfFile = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
            PdfWriter.GetInstance(pdfFile, new FileStream("faktura.pdf", FileMode.OpenOrCreate));
            pdfFile.Open();
            var spacer = new Paragraph("")
            {
                SpacingBefore = 10f,
                SpacingAfter = 10f,
            };
            var headerTable = new PdfPTable(new[] { .75f, 2f })
            {
                
            };

            var paragraph = new Paragraph();

            headerTable.AddCell("Date");
            headerTable.AddCell(DateTime.Now.ToString());
            pdfFile.Add(headerTable);
            pdfFile.Add(spacer);

            paragraph.Add("Seller: \n ADEDS Company \n ul.Wiejska 1 \n 00-001 Warszawa \n");
            pdfFile.Add(paragraph);

            paragraph.Clear();
            pdfFile.Add(spacer);
            paragraph.Add("Buyer: \n" + name + "\n" + address + "\n" + phone);
            pdfFile.Add(paragraph);
            pdfFile.Add(spacer);
            var table = new PdfPTable(new[] { 1f, 1f, 1f, 1f, 1f });
            table.AddCell("Name");
            table.AddCell("Type");
            table.AddCell("Model");
            table.AddCell("Series");
            table.AddCell("Price");
            foreach(var item in list)
            {
                table.AddCell(item.Name);
                table.AddCell(item.Type);
                table.AddCell(item.Model);
                table.AddCell(item.Series);
                table.AddCell(item.Price.ToString());
            }
            pdfFile.Add(table);
            pdfFile.Add(spacer);
            var tableFinished = new PdfPTable(new[] { 1f, 1f })
            {
                
            };
            tableFinished.AddCell("Price total:");
            double price = 0;
            foreach(var item in list)
            {
                price += item.Price;
            }
            tableFinished.AddCell(price.ToString());
            pdfFile.Add(tableFinished);
            pdfFile.Close();
            return "a";
        }
    }
    public class Receipt : ISettlementType
    {

        public string createSettlement(List<ModelItem> list, string name, string phone, string address)
        {
            var pdfFile = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
            PdfWriter.GetInstance(pdfFile, new FileStream("rachunek.pdf", FileMode.OpenOrCreate));
            pdfFile.Open();

            var paragraph = new Paragraph();
            var date = DateTime.Now.ToString();
            paragraph.Add("Seller: \n ADEDS Company \n ul.Wiejska 1 \n 00-001 Warszawa \n Date: " + date);
            pdfFile.Add(paragraph);
            var spacer = new Paragraph("")
            {
                SpacingBefore = 10f,
                SpacingAfter = 10f,
            };
            pdfFile.Add(spacer);

            paragraph.Clear();
            double price = 0;

            foreach(var item in list)
            {
                price += item.Price;
                paragraph.Add(item.Name + " " + item.Price.ToString() + "\n");
            }
            paragraph.Add("Total price: " + price.ToString());

            pdfFile.Add(paragraph);
            pdfFile.Close();
            return "b";
        }
    }

}
