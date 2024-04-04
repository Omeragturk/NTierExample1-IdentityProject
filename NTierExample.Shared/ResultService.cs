namespace NTierExample.Shared
{
    public class ResultService<TModel>
    {
		private List<ErrorItem> _errors;	

		public IEnumerable<ErrorItem> Errors => _errors;

        public bool HasError => _errors.Any();

        public TModel Model { get; set; }

        public ResultService()
        {
            _errors = new List<ErrorItem>();
        }

        public void AddErrorItem(string errorTitle, string errorMessage)
        {
            _errors.Add(new ErrorItem { ErrorTitle = errorTitle, ErrorMessage = errorMessage });
        }

    }
}
