namespace TranslatorApp.Core.Models
{
    public class Language
    {
        public int Id { get; }
        public string Name { get; }
        public string Code {  get; }

        public Language(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

    }
}