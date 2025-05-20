namespace ClassLibraryLevi.Data.Framework
{
    public abstract class BaseResult
    {
        private List<string> errors = [];
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors
        {
            get { return errors; }
        }

        public void AddError(string error)
        {
            errors.Add(error);
        }
    }
}
