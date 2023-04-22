using ChequeMate.Domain.Entities;

namespace ChequeMate.Domain.UnitTest
{
    public class InvoiceTests
    {
        [Fact]
        public void TotalAmount_ReturnsCorrectValue()
        {
            // Arrange
            var listItems = new List<ListItem>
            {
                new ListItem { Quantity = 2, TotalPrice = 10 },
                new ListItem { Quantity = 1, TotalPrice = 5 },
            };
            var invoice = new Invoice { ListItems = listItems };

            // Act
            var totalAmount = invoice.TotalAmount;

            // Assert
            Assert.Equal(15, totalAmount);
        }

        [Fact]
        public void TimeToPay_WhenNotPaid_ReturnsNull()
        {
            // Arrange
            var invoice = new Invoice { DueDate = DateTime.Now.AddDays(30) };

            // Act
            var timeToPay = invoice.TimeToPayInHours;

            // Assert
            Assert.Null(timeToPay);
        }

        [Fact]
        public void TimeToPayInHours_WhenPaid_ReturnsCorrectValue()
        {
            // Arrange
            var invoice = new Invoice
            {
                CreatedDate = DateTime.Now.AddHours(-20),
                PaymentDate = DateTime.Now.AddHours(-15),
                IsPaid = true,
            };

            // Act
            var timeToPayInHours = invoice.TimeToPayInHours;

            // Assert
            Assert.Equal(5, timeToPayInHours);
        }


        [Fact]
        public void SetAsPaid_SetsIsPaidToTrue()
        {
            // Arrange
            var invoice = new Invoice { IsPaid = false };

            // Act
            invoice.SetAsPaid();

            // Assert
            Assert.True(invoice.IsPaid == true);
        }

        [Fact]
        public void SetAsPaid_SetsPaymentDateToCurrentDate()
        {
            // Arrange
            var invoice = new Invoice { PaymentDate = null };

            // Act
            invoice.SetAsPaid();

            // Assert
            Assert.NotNull(invoice.PaymentDate);
            Assert.Equal(DateTime.Today, invoice.PaymentDate?.Date);
        }
    }
}
