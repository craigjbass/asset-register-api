using asset_register_api.Factory;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.HomesEngland.UseCase;
using asset_register_api.Interface;
using asset_register_api.Interface.UseCase;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Factory
{
    [TestFixture]
    public class UseCaseFactoryTest
    {
        private IUseCaseFactory _useCaseFactory;

        [SetUp]
        public void Setup()
        {
            _useCaseFactory = new UseCaseFactory();
        }
        
        [Test]
        public void GetUseCaseReturnsCorrectObject()
        {
            ReturnsCorrectObjectExampleOne();
            ReturnsCorrectObjectExampleTwo();
        }

        private void ReturnsCorrectObjectExampleOne()
        {
            IGetAssetUseCase useCase = new GetAsset(null);
            _useCaseFactory.AddUseCase(useCase);
            var returnedUseCase = _useCaseFactory.GetUseCase<IGetAssetUseCase>();
            Assert.AreEqual(useCase, returnedUseCase);
        }
        private void ReturnsCorrectObjectExampleTwo()
        {
            string simpleString = new string("Scout The Dog");
            _useCaseFactory.AddUseCase(simpleString);
            var returnedSimpleString = _useCaseFactory.GetUseCase<string>();
            Assert.AreEqual(simpleString, returnedSimpleString);
        }

        [Test]
        public void ThrowsNoUseCaseIfTypeNotFound()
        {
            string scout = "The Dog";
            _useCaseFactory.AddUseCase(scout);
            Assert.Throws<NoUseCaseException>(() => _useCaseFactory.GetUseCase<IGetAssetUseCase>());
        }
    }
}