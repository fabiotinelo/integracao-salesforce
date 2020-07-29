using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Meetup.IntegracaoSalesForce
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ColumnDelimiterEnum
	{
		[EnumMember(Value = "BACKQUOTE")]
		BACKQUOTE,
		[EnumMember(Value = "CARET")]
		CARET,
		[EnumMember(Value = "COMMA")]
		COMMA,
		[EnumMember(Value = "PIPE")]
		PIPE,
		[EnumMember(Value = "SEMICOLON")]
		SEMICOLON,
		[EnumMember(Value = "TAB")]
		TAB,
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum ContentTypeEnum
	{
		[EnumMember(Value = "CSV")]
		CSV
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum LineEndingEnum
	{
		[EnumMember(Value = "LF")]
		LF,
		[EnumMember(Value = "CRLF")]
		CRLF
	}


	[JsonConverter(typeof(StringEnumConverter))]
	public enum OperationEnum
	{
		[EnumMember(Value = "insert")]
		insert,
		[EnumMember(Value = "delete")]
		delete,
		[EnumMember(Value = "update")]
		update,
		[EnumMember(Value = "upsert")]
		upsert,
		[EnumMember(Value = "query")]
		query,
		[EnumMember(Value = "queryall")]
		queryall,
		[EnumMember(Value = "hardDelete")]
		hardDelete
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum JobStateEnum
	{
		[EnumMember(Value = "InProgress")]
		InProgress,
		[EnumMember(Value = "Open")]
		Open,
		[EnumMember(Value = "UploadComplete")]
		UploadComplete,
		[EnumMember(Value = "Aborted")]
		Aborted,
		[EnumMember(Value = "JobComplete")]
		JobComplete,
		[EnumMember(Value = "Failed")]
		Failed,
		[EnumMember(Value = "Closed")]
		Closed
	}


	[JsonConverter(typeof(StringEnumConverter))]
	public enum BatchStateEnum
	{
		[EnumMember(Value = "Queued")]
		Queued,
		[EnumMember(Value = "InProgress")]
		InProgress,
		[EnumMember(Value = "Completed")]
		Completed,
		[EnumMember(Value = "Failed")]
		Failed,
		[EnumMember(Value = "Not Processed")]
		NotProcessed
	}


	[JsonConverter(typeof(StringEnumConverter))]
	public enum JobTypeEnum
	{
		[EnumMember(Value = "BigObjectIngest")]
		BigObjectIngest,
		[EnumMember(Value = "Classic")]
		Classic,
		[EnumMember(Value = "V2Ingest")]
		V2Ingest
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum ConcurrencyModeEnum
	{
		[EnumMember(Value = "Parallel")]
		Parallel,
		[EnumMember(Value = "Serial")]
		Serial
	}
}
