using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SentinelFlow.Api.Data;
using SentinelFlow.Api.Models;
using SentinelFlow.Api.Services;

namespace SentinelFlow.Api.Controllers;
[ApiController]
[Route("api/incidents")]
public class IncidentsController(AppDbContext db,MlClient ml):ControllerBase {
 [HttpGet]
 public async Task<IActionResult> Get()=>Ok(await db.Incidents.OrderByDescending(x=>x.CreatedAt).Take(30).ToListAsync());

 [HttpPost("simulate")]
 public async Task<IActionResult> Simulate(){
  var latency=1840d; var rate=18.5d; var failures=17d;
  var result=await ml.Detect(latency,rate,failures);
  var incident=new Incident{
   Title="Checkout API degradation",
   Severity=result.IsAnomaly?"HIGH":"LOW",
   LatencyMs=latency,Http5xxRate=rate,DbFailures=failures,
   AnomalyScore=result.AnomalyScore,
   Evidence="API latency increased sharply\nDatabase failures detected\nHTTP 5xx rate increased",
   Suggestions="Inspect SQL connection pool\nCheck database availability\nReview recent application changes"
  };
  db.Incidents.Add(incident); await db.SaveChangesAsync();
  return Ok(incident);
 }
}
