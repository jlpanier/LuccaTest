using Lucca.Controllers;
using Lucca.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lucca.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestPopulate()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<InitController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new InitController(logger, config);

            var result = controller.Populate();
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Count>=19);
        }

        [TestMethod]
        public void TestCustomer()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<CustomerController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new CustomerController(logger, config);

            ActionResult<ResponseCustomer> resCreate = controller.Create("Pierre", "Corneille", "0");
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Unknon devise");

            resCreate = controller.Create("Pierre", "Corneille", "EUR");
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsTrue(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Success");

            ResponseCustomer resGet = controller.Get("Corneille", "Pierre");
            Assert.IsNotNull(resGet);
            Assert.IsNotNull(resGet.Customer);
            Assert.IsTrue(resGet.Success);
            Assert.AreEqual(resGet.Customer.LastName, "Corneille");

            ResponseCustomer resDel = controller.Delete("Corneille", "Pierre");
            Assert.IsNotNull(resDel);
            Assert.IsNotNull(resDel.Customer);
            Assert.IsTrue(resDel.Success);
            Assert.AreEqual(resDel.Customer.LastName, "Corneille");

            resDel = controller.Delete("Corneille", "Pierre");
            Assert.IsNotNull(resDel);
            Assert.IsNull(resDel.Customer);
            Assert.IsFalse(resDel.Success);
        }

        [TestMethod]
        public void TestDevise()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<DeviseController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new DeviseController(logger, config);

            ResponseDevise resCreate = controller.Create(new Request.RequestDevise()
            {
                Code="",
                Label="Test",
                Numero=0
            });
            Assert.IsNotNull(resCreate);
            Assert.IsFalse(resCreate.Success);

            resCreate = controller.Create(new Request.RequestDevise()
            {
                Code = "NEW",
                Label = "Test",
                Numero = 123
            });
            Assert.IsNotNull(resCreate);
            Assert.IsTrue(resCreate.Success);
            Assert.AreEqual(resCreate.Message, "Success");


            ResponseDevise resGet = controller.Get("NEW");
            Assert.IsNotNull(resGet);
            Assert.IsNotNull(resGet.Devise);
            Assert.IsTrue(resGet.Success);
            Assert.AreEqual(resGet.Devise.Code, "NEW");
            Assert.AreEqual(resGet.Devise.Label, "Test");
            Assert.AreEqual(resGet.Devise.Numero, 123);

            ResponseDevise resDel = controller.Delete("NEW");
            Assert.IsNotNull(resGet);
            Assert.IsNotNull(resGet.Devise);
            Assert.IsTrue(resGet.Success);
            Assert.AreEqual(resDel.Devise.Code, "NEW");

            resDel = controller.Delete("NEW");
            Assert.IsNotNull(resGet);
            Assert.IsNull(resDel.Devise);
            Assert.IsFalse(resDel.Success);
            Assert.AreEqual(resDel.Message, "Not Found");
        }

        [TestMethod]
        public void TestTransactionNegativeAmount()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TransactionController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new TransactionController(logger, config);

            ActionResult<ResponseTransaction> resCreate = controller.Create(new Request.RequestTransaction()
            {
                Amount = -2,
                LastName = "Stark",
                FirstName = "Anthony",
                CodeDevise="USD",
                CodeNature="RESTO",
                Commentaire="Un commentaire",
                EffectiveOn=DateTime.Now.AddDays(-3),
            });
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Value cannot be null. (Parameter 'amount')");
        }

        [TestMethod]
        public void TestTransactionWrongDevise()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TransactionController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new TransactionController(logger, config);

            ActionResult<ResponseTransaction> resCreate = controller.Create(new Request.RequestTransaction()
            {
                Amount = 123.45,
                LastName = "Stark",
                FirstName = "Anthony",
                CodeDevise = "EUR",
                CodeNature = "RESTO",
                Commentaire = "Un commentaire",
                EffectiveOn = DateTime.Now.AddDays(-3),
            });
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Invalid Devise");
        }

        [TestMethod]
        public void TestTransactionUnknownUser()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TransactionController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new TransactionController(logger, config);

            ActionResult<ResponseTransaction> resCreate = controller.Create(new Request.RequestTransaction()
            {
                Amount = 123.45,
                LastName = "Bonaparte",
                FirstName = "Napoléon",
                CodeDevise = "USD",
                CodeNature = "RESTO",
                Commentaire = "Un commentaire",
                EffectiveOn = DateTime.Now.AddDays(-3),
            });
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Invalid Customer");
        }

        [TestMethod]
        public void TestTransactionWrongType()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TransactionController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new TransactionController(logger, config);

            ActionResult<ResponseTransaction> resCreate = controller.Create(new Request.RequestTransaction()
            {
                Amount = 123.45,
                LastName = "Stark",
                FirstName = "Anthony",
                CodeDevise = "USD",
                CodeNature = "WRONG",
                Commentaire = "Un commentaire",
                EffectiveOn = DateTime.Now.AddDays(-3),
            });
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Invalid Nature Transaction");
        }

        [TestMethod]
        public void TestTransactionCommentaire()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TransactionController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new TransactionController(logger, config);

            ActionResult<ResponseTransaction> resCreate = controller.Create(new Request.RequestTransaction()
            {
                Amount = 123.45,
                LastName = "Stark",
                FirstName = "Anthony",
                CodeDevise = "USD",
                CodeNature = "HOTEL",
                Commentaire = " ",
                EffectiveOn = DateTime.Now.AddDays(-3),
            });
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Invalid Comment");
        }

        [TestMethod]
        public void TestTransactionDateFuture()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TransactionController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new TransactionController(logger, config);

            ActionResult<ResponseTransaction> resCreate = controller.Create(new Request.RequestTransaction()
            {
                Amount = 123.45,
                LastName = "Stark",
                FirstName = "Anthony",
                CodeDevise = "USD",
                CodeNature = "HOTEL",
                Commentaire = "Un commentaire",
                EffectiveOn = DateTime.Now.AddDays(3),
            });
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Invalid Date");
        }

        [TestMethod]
        public void TestTransactionDatePast()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TransactionController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new TransactionController(logger, config);

            ActionResult<ResponseTransaction> resCreate = controller.Create(new Request.RequestTransaction()
            {
                Amount = 123.45,
                LastName = "Stark",
                FirstName = "Anthony",
                CodeDevise = "USD",
                CodeNature = "HOTEL",
                Commentaire = "Un commentaire",
                EffectiveOn = DateTime.Now.AddMonths(-3).AddDays(-1),
            });
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Invalid Date");
        }

        [TestMethod]
        public void TestTransactionCreate()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TransactionController>();

            var testConfiguration = new Dictionary<string, string>
            {
                {"Mode", "Test"},
                {"DatabasePath", "lucca.sqlite"},
            };

            IConfiguration config = new ConfigurationBuilder().AddInMemoryCollection(testConfiguration).Build();

            var controller = new TransactionController(logger, config);

            var requesttransaction = new Request.RequestTransaction()
            {
                Amount = 123.45,
                LastName = "Stark",
                FirstName = "Anthony",
                CodeDevise = "USD",
                CodeNature = "HOTEL",
                Commentaire = "Un commentaire",
                EffectiveOn = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0),
            };

            ActionResult<ResponseTransaction> resCreate = controller.Create(requesttransaction);
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsTrue(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Success");

            ResponseTransactions resGet = controller.Get("Anthony", "Stark");
            Assert.IsNotNull(resGet);
            Assert.IsTrue(resGet.Success);
            Assert.AreEqual(resGet.Message, "Success");
            Assert.IsNotNull(resGet.Transactions);
            Assert.IsTrue(resGet.Transactions.Any(_ => _.EffectiveOn == requesttransaction.EffectiveOn));

            resCreate = controller.Create(requesttransaction);
            Assert.IsNotNull(resCreate);
            Assert.IsNotNull(resCreate.Value);
            Assert.IsFalse(resCreate.Value.Success);
            Assert.AreEqual(resCreate.Value.Message, "Duplicate Transaction");


        }
    }
}