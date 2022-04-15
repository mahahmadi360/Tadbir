using AutoMapper;
using Mah.Tadbir.Entity;
using Mah.Tadbir.Web.Config;
using Mah.Tadbir.Web.Model;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class AutoMapperTests
    {
        private int Id = 1;

        IMapper mapper;
        public AutoMapperTests()
        {
            mapper = new Mapper(MapperConfig.GetMapperConfiguration());
        }

        [Fact]
        public void Map_InvoiceStuffToModel_FillAllProperties()
        {
            var invoiceStuff = GetRandomInvoiceStuff();

            var mappedModel = mapper.Map<InvoiceStuffModel>(invoiceStuff);

            CheckInvoiceStuffMapping(mappedModel, invoiceStuff);
        }

        [Fact]
        public void Map_InvoiceStuffToEntity_FillAllProperties()
        {
            var invoiceStuffModel = GetRandomInvoiceStuffModel();

            var mappedEntity = mapper.Map<InvoiceStuff>(invoiceStuffModel);

            CheckInvoiceStuffMapping(invoiceStuffModel, mappedEntity);
        }

        [Fact]
        public void Map_InvoiceToModel_FillAllProperties()
        {
            var invoice = GetRandomInvoice();

            var mappedModel = mapper.Map<InvoiceModel>(invoice);

            CheckInvoiceMapping(mappedModel, invoice);
        }

        [Fact]
        public void Map_InvoiceToEntity_FillAllProperties()
        {
            var invoiceModel = GetRandomInvoiceModel();

            var mappedEntity = mapper.Map<Invoice>(invoiceModel);

            CheckInvoiceMapping(invoiceModel, mappedEntity);
        }

        private void CheckInvoiceStuffMapping(InvoiceStuffModel invoiceStuffsModel,
           InvoiceStuff invoiceStuff)
        {
            Assert.Equal(invoiceStuff.Id, invoiceStuffsModel.Id);
            Assert.Equal(invoiceStuff.InvoiceId, invoiceStuffsModel.InvoiceId);
            Assert.Equal(invoiceStuff.OffPercent, invoiceStuffsModel.OffPercent);
            Assert.Equal(invoiceStuff.Stuff.Name, invoiceStuffsModel.StuffName);
            Assert.Equal(invoiceStuff.StuffId, invoiceStuffsModel.StuffId);
            Assert.Equal(invoiceStuff.StuffPrice, invoiceStuffsModel.StuffPrice);
            Assert.Equal(invoiceStuff.StuffQuantity, invoiceStuffsModel.StuffQuantity);
        }

        private void CheckInvoiceMapping(InvoiceModel invoiceModel,
           Invoice invoice)
        {
            Assert.Equal(invoice.Id, invoiceModel.Id);
            Assert.Equal(invoice.Description, invoiceModel.Description);
            Assert.Equal(invoice.CustomerName, invoiceModel.CustomerName);
            Assert.Equal(invoice.RegisterDate, invoiceModel.RegisterDate);
            Assert.Equal(invoice.InvoiceStuffs.Count(), invoiceModel.InvoiceStuffs.Count());
            foreach (var invoiceStuff in invoice.InvoiceStuffs)
            {
                Assert.Contains(invoiceModel.InvoiceStuffs, a => a.Id == invoiceStuff.Id);
                CheckInvoiceStuffMapping(
                    invoiceModel.InvoiceStuffs.First(a => a.Id == invoiceStuff.Id), invoiceStuff);
            }
        }

        private Invoice GetRandomInvoice()
        {
            var newId = Id++;
            var random = new Random();
            var invoiceStuffs = Enumerable.Repeat(GetRandomInvoiceStuff(), 5).ToList();
            return Mock.Of<Invoice>(a =>
            a.Id == newId &&
            a.Description == Guid.NewGuid().ToString("N") &&
            a.CustomerName == Guid.NewGuid().ToString("N") &&
            a.RegisterDate == DateTime.Now &&
            a.InvoiceStuffs == invoiceStuffs
            );
        }

        private InvoiceModel GetRandomInvoiceModel()
        {
            var newId = Id++;
            var random = new Random();
            var invoiceStuffs = Enumerable.Repeat(GetRandomInvoiceStuffModel(), 5).ToList();
            return Mock.Of<InvoiceModel>(a =>
            a.Id == newId &&
            a.Description == Guid.NewGuid().ToString("N") &&
            a.CustomerName == Guid.NewGuid().ToString("N") &&
            a.RegisterDate == DateTime.Now &&
            a.InvoiceStuffs == invoiceStuffs
            );
        }

        private InvoiceStuff GetRandomInvoiceStuff()
        {
            var newId = Id++;
            var newStuffId = Id++;
            var random = new Random();
            return Mock.Of<InvoiceStuff>(a => a.Id == newId
            && a.InvoiceId == random.Next()
            && a.OffPercent == random.Next(0, 100)
            && a.Stuff == new Stuff
            {
                Id = newStuffId,
                Name = Guid.NewGuid().ToString("N")
            }
            && a.StuffId == a.Stuff.Id
            && a.StuffPrice == random.Next(0, int.MaxValue)
            && a.StuffQuantity == random.Next(0, int.MaxValue)
             );
        }

        private InvoiceStuffModel GetRandomInvoiceStuffModel()
        {
            var newId = Id++;
            var newStuffId = Id++;
            var random = new Random();
            return Mock.Of<InvoiceStuffModel>(a => a.Id == newId
            && a.InvoiceId == random.Next()
            && a.OffPercent == random.Next(0, 100)
            && a.StuffId == newStuffId
            && a.StuffName == Guid.NewGuid().ToString("N")
            && a.StuffPrice == random.Next(0, int.MaxValue)
            && a.StuffQuantity == random.Next(0, int.MaxValue)
             );
        }
    }
}
