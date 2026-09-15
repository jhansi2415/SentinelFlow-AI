using Microsoft.EntityFrameworkCore;
using SentinelFlow.Api.Models;
namespace SentinelFlow.Api.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options){
 public DbSet<Incident> Incidents=>Set<Incident>();
}
