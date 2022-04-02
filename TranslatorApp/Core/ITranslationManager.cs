using TranslatorApp.Core.Models;

namespace TranslatorApp.Core
{
    public interface ITranslationManager
    {
        Task<string> TranslateAsync(string input, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken);
        List<Language> GetLanguages();
        decimal EstimateTranslationCost(string input);
    }
}