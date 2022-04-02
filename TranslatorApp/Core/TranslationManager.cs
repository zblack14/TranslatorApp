using TranslatorApp.Core.Models;
using TranslatorApp.Models;

namespace TranslatorApp.Core
{
    public class TranslationManager : ITranslationManager
    {
        private readonly ITranslationRepository _translationRepository;

        public TranslationManager(ITranslationRepository translationRepository)
        {
            _translationRepository = translationRepository ?? throw new ArgumentNullException(nameof(translationRepository));
        }

        public Task<string> TranslateAsync(string input, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken)
        {
            //Bypassing request if there is no change in language to reduce network traffic.
            if (sourceLanguage == targetLanguage) return Task.FromResult(input);

            return _translationRepository.TranslateAsync(input, sourceLanguage, targetLanguage, cancellationToken);
        }

        public List<Language> GetLanguages()
        {
            return Languages.LanguagesList;
        }

        public decimal EstimateTranslationCost(string input)
        {
            //Current cost is 0.000015 per character after free-tier - 04/01/2022
            return input.Length * 0.000015M;
        }
    }
}