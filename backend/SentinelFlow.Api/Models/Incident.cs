namespace SentinelFlow.Api.Models;
public class Incident {
 public int Id {get;set;}
 public string Title {get;set;}="";
 public string Severity {get;set;}="";
 public double LatencyMs {get;set;}
 public double Http5xxRate {get;set;}
 public double DbFailures {get;set;}
 public double AnomalyScore {get;set;}
 public string Evidence {get;set;}="";
 public string Suggestions {get;set;}="";
 public DateTime CreatedAt {get;set;}=DateTime.UtcNow;
}
