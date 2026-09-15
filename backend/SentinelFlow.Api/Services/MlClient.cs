using System.Net.Http.Json;
namespace SentinelFlow.Api.Services;
public class MlClient(HttpClient client){
 public async Task<Result> Detect(double latency,double rate,double db){
  var r=await client.PostAsJsonAsync("/detect",new {latencyMs=latency,http5xxRate=rate,dbFailures=db});
  r.EnsureSuccessStatusCode();
  return await r.Content.ReadFromJsonAsync<Result>() ?? new(false,0);
 }
 public record Result(bool IsAnomaly,double AnomalyScore);
}
