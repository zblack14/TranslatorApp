namespace TranslatorApp.Core
{
    public interface ITranslationRepository
    {
        Task<string> TranslateAsync(string input, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken);
    }
}