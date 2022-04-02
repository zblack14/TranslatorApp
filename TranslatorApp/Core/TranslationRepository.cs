using Amazon.Translate;
using Amazon.Translate.Model;

namespace TranslatorApp.Core
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly IAmazonTranslate _amazonTranslate;

        public TranslationRepository(IAmazonTranslate amazonTranslate)
        {
            _amazonTranslate = amazonTranslate ?? throw new ArgumentNullException(nameof(amazonTranslate));
        }

        public async Task<string> TranslateAsync(string input, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken)
        {
            var request = new TranslateTextRequest
            {
                Text = input,
                SourceLanguageCode = sourceLanguage,
                TargetLanguageCode = targetLanguage
            };

            var response = await _amazonTranslate.TranslateTextAsync(request, cancellationToken);
            return response.TranslatedText;
        }
    }
}