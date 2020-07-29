using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.IntegracaoSalesForce
{
	public class ResponseJob 
	{

		[JsonProperty("apiVersion")]
		public string APIVersion { get; set; }


		[JsonProperty("columnDelimiter")]
		public ColumnDelimiterEnum ColumnDelimiter { get; set; }


		[JsonProperty("concurrencyMode")]
		public ConcurrencyModeEnum ConcurrencyMode { get; set; }


		[JsonProperty("contentType")]
		public ContentTypeEnum ContentType { get; set; }


		[JsonProperty("contentUrl")]
		public string ContentUrl { get; set; }


		[JsonProperty("createdById")]
		public string CreatedById { get; set; }


		[JsonProperty("createdDate")]
		public DateTime CreatedDate { get; set; }

		[JsonProperty("systemModstamp")]
		public DateTime SystemModstamp { get; set; }


		[JsonProperty("externalIdFieldName")]
		public string ExternalIdFieldName { get; set; }


		[JsonProperty("id")]
		public string ID { get; set; }


		[JsonProperty("jobType")]
		public JobTypeEnum JobType { get; set; }


		[JsonProperty("lineEnding")]
		public LineEndingEnum LineEnding { get; set; }


		[JsonProperty("object")]
		public string Object { get; set; }


		[JsonProperty("operation")]
		public OperationEnum Operation { get; set; }


		[JsonProperty("state")]
		public JobStateEnum JobState { get; set; }

	}
}
