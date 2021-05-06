namespace ReflectionTest.Models
{
    public class FieldUML
    {
        public string FieldName { get; set; }
        public string Accesibility { get; set; }
        public string FieldType { get; set; }

        //TODO-?   public Accesibilities Accesibility { get; set; }
        //TODO-?  public DataTypes DataType { get; set; }

        public string StartingValue { get; set; }

        public AccesibilityUML FullAccesibility { get; set; }
    }
   


}