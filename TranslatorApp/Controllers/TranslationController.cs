using Microsoft.AspNetCore.Mvc;
using TranslatorApp.Core;
using TranslatorApp.Models;
using Language = TranslatorApp.Controllers.Models.Language;

namespace TranslatorApp.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly ILogger<TranslationController> _logger;
        private readonly ITranslationManager _translationManager;

        public TranslationController(ILogger<TranslationController> logger, ITranslationManager translationManager)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _translationManager = translationManager ?? throw new ArgumentNullException(nameof(translationManager));

        }

        [HttpGet("translate")]
        public async Task<IActionResult> Translate(string input, string sourceLanguageCode, string targetLanguageCode, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(input)) return BadRequest("Input must have a value.");
            if(Languages.GetLanguageFromCode(sourceLanguageCode) == null) return BadRequest("Source language code is not valid.");
            if(Languages.GetLanguageFromCode(targetLanguageCode) == null) return BadRequest("Target language code is not valid.");

            try
            {
                return Ok(await _translationManager.TranslateAsync(input, sourceLanguageCode, targetLanguageCode, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Translation request has failed.");
                return StatusCode(500);
            }
        }

        [HttpGet("getLanguages")]
        public IActionResult GetLanguagesAsync()
        {
            try
            {
                return Ok(_translationManager.GetLanguages().Select(Language.Convert));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Languages request has failed.");
                return StatusCode(500);
            }
        }

        [HttpGet("estimateTranslationCost")]
        public IActionResult EstimateTranslationCost(string input)
        {
            try
            {
                return Ok(_translationManager.EstimateTranslationCost(input));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Estimate Translation Cost request has failed.");
                return StatusCode(500);
            }
        }
    }
}