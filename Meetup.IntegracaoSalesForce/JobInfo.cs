using Newtonsoft.Json;
using System;

namespace Meetup.IntegracaoSalesForce
{
	public class JobInfo 
	{
		[JsonProperty("apexProcessingTime")]
		public long ApexProcessingTime { get; set; }

		[JsonProperty("apiActiveProcessingTime")]
		public long ApiActiveProcessingTime { get; set; }

		[JsonProperty("apiVersion")]
		public string ApiVersion { get; set; }

		[JsonProperty("columnDelimiter")]
		public ColumnDelimiterEnum ColumnDelimiter { get; set; }

		[JsonProperty("concurrencyMode")]
		public ConcurrencyModeEnum ConcurrencyMode { get; set; }

		[JsonProperty("contentType")]
		public string ContentType { get; set; }

		[JsonProperty("contentUrl")]
		public string ContentUrl { get; set; }

		[JsonProperty("createdById")]
		public string CreatedById { get; set; }

		[JsonProperty("createdDate")]
		public DateTime CreatedDate { get; set; }

		[JsonProperty("externalIdFieldName")]
		public string ExternalIdFieldName { get; set; }

		[JsonProperty("id")]
		public string ID { get; set; }

		[JsonProperty("jobType")]
		public JobTypeEnum JobType { get; set; }

		[JsonProperty("lineEnding")]
		public LineEndingEnum LineEnding { get; set; }

		[JsonProperty("numberRecordsFailed")]
		public int NumberRecordsFailed { get; set; }

		[JsonProperty("numberRecordsProcessed")]
		public int NumberRecordsProcessed { get; set; }

		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("operation")]
		public OperationEnum Operation { get; set; }

		[JsonProperty("retries")]
		public int Retries { get; set; }

		[JsonProperty("state")]
		public JobStateEnum State { get; set; }

		[JsonProperty("systemModstamp")]
		public DateTime SystemModstamp { get; set; }

		[JsonProperty("totalProcessingTime")]
		public long TotalProcessingTime { get; set; }

	}
}
