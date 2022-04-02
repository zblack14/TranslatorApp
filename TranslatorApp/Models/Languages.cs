using TranslatorApp.Core.Models;

namespace TranslatorApp.Models
{
    public static class Languages
    {
        //Language source:
        //https://docs.aws.amazon.com/translate/latest/dg/what-is.html
        public static List<Language> LanguagesList = new()
        {
            new Language(1, "Afrikaans", "af"),
            new Language(2, "Albanian", "sq"),
            new Language(3, "Amharic", "am"),
            new Language(4, "Arabic", "ar"),
            new Language(5, "Armenian", "hy"),
            new Language(6, "Azerbaijani", "az"),
            new Language(7, "Bengali", "bn"),
            new Language(8, "Bosnian", "bs"),
            new Language(9, "Bulgarian", "bg"),
            new Language(10, "Catalan", "ca"),
            new Language(11, "Chinese (Simplified)", "zh"),
            new Language(12, "Chinese (Traditional)", "zh-TW"),
            new Language(13, "Croatian", "hr"),
            new Language(14, "Czech", "cs"),
            new Language(15, "Danish", "da"),
            new Language(16, "Dari", "fa-AF"),
            new Language(17, "Dutch", "nl"),
            new Language(18, "English", "en"),
            new Language(19, "Estonian", "et"),
            new Language(20, "Farsi (Persian)", "fa"),
            new Language(21, "Filipin Tagalog", "tl"),
            new Language(22, "Finnish", "fi"),
            new Language(23, "French", "fr"),
            new Language(24, "French (Canada)", "fr-CA"),
            new Language(25, "Georgian", "ka"),
            new Language(26, "German", "de"),
            new Language(27, "Greek", "el"),
            new Language(28, "Gujarati", "gu"),
            new Language(29, "Haitian (Creole)", "ht"),
            new Language(30, "Hausa", "ha"),
            new Language(31, "Hebrew", "he"),
            new Language(32, "Hindi", "hi"),
            new Language(33, "Hungarian", "hu"),
            new Language(34, "Icelandic", "is"),
            new Language(35, "Indonesian", "id"),
            new Language(36, "Irish", "ga"),
            new Language(37, "Italian", "it"),
            new Language(38, "Japanese", "ja"),
            new Language(39, "Kannada", "kn"),
            new Language(40, "Kazakh", "kk"),
            new Language(41, "Korean", "ko"),
            new Language(42, "Latvian", "lv"),
            new Language(43, "Lithuanian", "lt"),
            new Language(44, "Macedonian", "mk"),
            new Language(45, "Malay", "ms"),
            new Language(46, "Malayalam", "ml"),
            new Language(47, "Maltese", "mt"),
            new Language(48, "Marathi", "mr"),
            new Language(49, "Mongolian", "mn"),
            new Language(50, "Norwegian", "no"),
            new Language(51, "Pashto", "ps"),
            new Language(52, "Polish", "pl"),
            new Language(53, "Portuguese", "pt"),
            new Language(54, "Portuguese (Portugal)", "pt-PT"),
            new Language(55, "Punjabi", "pa"),
            new Language(56, "Romanian", "ro"),
            new Language(57, "Russian", "ru"),
            new Language(58, "Serbian", "sr"),
            new Language(59, "Sinhala", "si"),
            new Language(60, "Slovak", "sk"),
            new Language(61, "Slovenian", "sl"),
            new Language(62, "Somali", "so"),
            new Language(63, "Spanish", "es"),
            new Language(64, "Spanish (Mexico)", "es-MX"),
            new Language(65, "Swahili", "sw"),
            new Language(66, "Swedish", "sv"),
            new Language(67, "Tamil", "ta"),
            new Language(68, "Telugu", "te"),
            new Language(69, "Thai", "th"),
            new Language(70, "Turkish", "tr"),
            new Language(71, "Ukrainian", "uk"),
            new Language(72, "Urdu", "ur"),
            new Language(73, "Uzbek", "uz"),
            new Language(74, "Vietnamese", "vi"),
            new Language(75, "Welsh", "cy")
        };

        public static Language? GetLanguageFromId(int id)
        {
            return LanguagesList.Find(lang => lang.Id.Equals(id)) ?? null;
        }
        public static Language? GetLanguageFromName(string name)
        {
            return LanguagesList.Find(lang => lang.Name.Equals(name)) ?? null;
        }
        public static Language? GetLanguageFromCode(string code)
        {
            return LanguagesList.Find(lang => lang.Code.Equals(code)) ?? null;
        }
    }
}