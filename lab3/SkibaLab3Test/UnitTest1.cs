using SkibaLab3;
namespace SkibaLab3Test
        
{
    public class Tests
    {
        [SetUp]
        public void Setup()

        {
            
        }

        [Test]
        public void T_001_DevideFIO_BaseFlow()
        {
           
            string actualReturnValue = "";
            string expectedReturnValue = "Skiba A. E.";
            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = FioTransformer.CreateFioInitials("Skiba", "Alexander", "Edikovich");
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);
            
        }
        [Test]
        public void T_002_DevideFIO_EmptySurname()
        {

            string actualReturnValue = "";
            string expectedReturnValue = "A. E.";
            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = FioTransformer.CreateFioInitials("", "Alexander", "Edikovich");
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);

        }

        [Test]
        public void T_003_DevideFIO_EmptyName()
        {

            string actualReturnValue = "";
            string expectedReturnValue = "Skiba";
            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = FioTransformer.CreateFioInitials("Skiba", "", "Edikovich");
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);

        }

        [Test]
        public void T_004_DevideFIO_EmptyPatronimyc()
        {

            string actualReturnValue = "";
            string expectedReturnValue = "Skiba A.";
            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = FioTransformer.CreateFioInitials("Skiba", "Alexander","");
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);

        }

        [Test]
        public void T_005_DevideFIO_ForbiddenSymbols()
        {

            string actualReturnValue = "";
            string expectedReturnValue = "ForbiddenSymbolsException";
            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = FioTransformer.CreateFioInitials("Skiba!", "Alexander", "Edikovich");
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);

        }


        [Test]
        public void T_006_DevideFIO_EmptyInput()
        {

            string actualReturnValue = "";
            string expectedReturnValue = "EmptyException";
            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = FioTransformer.CreateFioInitials("", "", "");
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);

        }

        


        [Test]
        public void T_008_SuccessCopyFromBuffer()
        {

            FioTransformer.buffer.paste = "Skiba Alexander Edikovich";
            string actualReturnValue = "";
            string expectedReturnValue = "Skiba A. E.";
            Assert.DoesNotThrow(() =>
            {
                actualReturnValue = FioTransformer.splitAndTest();
            });
            Assert.AreEqual(expectedReturnValue, actualReturnValue);

        }

        [Test]
        public void Success()
        {
            Assert.Pass();
        }

    }
}