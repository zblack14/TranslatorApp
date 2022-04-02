namespace TranslatorApp.Controllers.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code {  get; set; }

        public static Language Convert(Core.Models.Language coreModel)
        {
            return new Language { Id = coreModel.Id, Name = coreModel.Name, Code = coreModel.Code };
        }

    }
}