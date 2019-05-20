namespace ContactCatalog
{
    public class CommunicationMethodModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public CommunicationTypeModel Type { get; set; }
        public bool IsPrefered { get; set; }
    }
}
