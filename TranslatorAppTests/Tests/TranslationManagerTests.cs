using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TranslatorApp.Core;

namespace TranslatorAppTests.Tests
{
    public class TranslationManagerTests
    {
        private ITranslationManager _translationManager;
        private Mock<ITranslationRepository> _translationRepository;

        [SetUp]
        public void Setup()
        {
            _translationRepository = new Mock<ITranslationRepository>(MockBehavior.Strict);
            _translationManager = new TranslationManager(_translationRepository.Object);
        }

        [Test]
        public async Task Valid_Input_Returns_Successful_Response()
        {
            _translationRepository.Setup(m => m.TranslateAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync("hey, ¿cómo estás?");

            var actual = await _translationManager.TranslateAsync("hey, how are you", "en", "es", CancellationToken.None);
            const string expected = "hey, ¿cómo estás?";
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public async Task If_Source_and_Target_Languages_Match_Bypass_Repository()
        {
            const string repositoryResponse = "this should not hit.";
            _translationRepository.Setup(m => m.TranslateAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(repositoryResponse);

            const string input = "hey, how are you";
            var actual = await _translationManager.TranslateAsync(input, "en", "en", CancellationToken.None);

            Assert.AreEqual(actual, input);
            Assert.AreNotEqual(actual, repositoryResponse);
        }
    }
}