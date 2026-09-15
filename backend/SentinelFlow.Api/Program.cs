using Microsoft.EntityFrameworkCore;
using SentinelFlow.Api.Data;
using SentinelFlow.Api.Services;
var b=WebApplication.CreateBuilder(args);
b.Services.AddControllers(); b.Services.AddEndpointsApiExplorer(); b.Services.AddSwaggerGen();
b.Services.AddDbContext<AppDbContext>(o=>o.UseSqlServer(b.Configuration.GetConnectionString("DefaultConnection")));
b.Services.AddHttpClient<MlClient>(c=>c.BaseAddress=new Uri(b.Configuration["MlService:Url"]??"http://localhost:8000"));
b.Services.AddCors(o=>o.AddDefaultPolicy(p=>p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
var app=b.Build(); app.UseSwagger(); app.UseSwaggerUI(); app.UseCors(); app.MapControllers();
for(var i=0;i<12;i++){try{using var s=app.Services.CreateScope();s.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();break;}catch{Thread.Sleep(5000);}}
app.Run();
