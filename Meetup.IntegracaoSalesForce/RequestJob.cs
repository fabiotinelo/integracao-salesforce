using Newtonsoft.Json;

namespace Meetup.IntegracaoSalesForce
{
	public class RequestJob 
	{

		public RequestJob(string objectName,
							   OperationEnum operation,
							   string externalIdFieldName = null,
							   ColumnDelimiterEnum columnDelimiter = ColumnDelimiterEnum.COMMA,
							   ContentTypeEnum contentType = ContentTypeEnum.CSV,
							   LineEndingEnum lineEnding = LineEndingEnum.CRLF,
							   int maxLinesFileCSV = 10000,
							   string directoryWork = ""
						  )
		{
			Init(objectName, externalIdFieldName, operation, columnDelimiter, contentType, lineEnding, maxLinesFileCSV, directoryWork);
		}


		private void Init(string objectName,
						  string externalIdFieldName,
						  OperationEnum operation,
						  ColumnDelimiterEnum columnDelimiter,
						  ContentTypeEnum contentType,
							LineEndingEnum lineEnding,
						  int maxLinesFileCSV,
						  string directoryWork
						 )
		{
			ColumnDelimiter = columnDelimiter;
			ContentType = contentType;
			ExternalIdFieldName = externalIdFieldName;
			Operation = operation;
			LineEnding = lineEnding;
			Object = objectName;
			MaxLinesFileCSV = maxLinesFileCSV;
			DirectoryWork = directoryWork;
		}


		[JsonProperty("columnDelimiter")]
		public ColumnDelimiterEnum ColumnDelimiter { get; set; }


		[JsonProperty("contentType")]
		public ContentTypeEnum ContentType { get; set; }


		[JsonProperty("externalIdFieldName")]
		public string ExternalIdFieldName { get; set; }


		[JsonProperty("lineEnding")]
		public LineEndingEnum LineEnding { get; set; }


		[JsonProperty("object")]
		public string Object { get; set; }


		[JsonProperty("operation")]
		public OperationEnum Operation { get; set; }

		[JsonIgnore]
		public int MaxLinesFileCSV { get; set; }

		[JsonIgnore]
		public string DirectoryWork { get; set; }

		public void SetOperation(OperationEnum operation) => this.Operation = operation;
	}
}
