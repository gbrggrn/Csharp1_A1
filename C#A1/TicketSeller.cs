using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace C_A1
{
    internal class TicketSeller //---Holds data and functionality for buying a ticket.
    {
        private double AmountToPay { get; set; }
        private const double Price = 2.50;          //---Constant set "Price"
        private const double ChildDiscount = 0.2;   //---Constant set "ChildDiscount"
        private double AdultsPrice;
        private double ChildrensPrice;
        private string? Name { get; set; }
        
        public void CalculatePrice(string name, int numOfAdults, int numOfChildren) //---takes the user input generated in the buyTicket()-method of the Operations class and calculates output
        {
            double adultsPrice = numOfAdults * Price;
            double childrensPrice = (numOfChildren * Price) - (numOfChildren * Price * ChildDiscount);
            double amountToPay = adultsPrice + childrensPrice;

            Name = name;
            AdultsPrice = adultsPrice;
            ChildrensPrice = childrensPrice;
            AmountToPay = amountToPay;
        }

        public string ReceiptPrintFormat() //---Returns a formatted string 
        {
            return $"Adults total: {AdultsPrice}$\nChildren total: {ChildrensPrice}$\n\nAmount to pay: {AmountToPay}$";
        }
    }
}
