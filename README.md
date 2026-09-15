# SentinelFlow AI

SentinelFlow AI is a portfolio-scale incident intelligence platform. It receives application telemetry, detects abnormal behavior with machine learning, correlates related signals into incidents, and presents evidence and troubleshooting suggestions in a web dashboard.

## Stack
- Angular / TypeScript
- C# / .NET 8 / ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Python / FastAPI / scikit-learn
- Docker / Docker Compose
- Swagger / OpenAPI
- GitHub Actions CI

## Main features
- Generate demo production telemetry
- Detect metric anomalies with Isolation Forest
- Correlate latency, HTTP 5xx, and database failures
- Create and store incidents
- Show evidence and suggested investigation steps
- REST APIs and Swagger documentation
- Containerized local environment

## Run
Copy `.env.example` to `.env`, then run:

```bash
docker compose up --build
```

Open:
- Dashboard: http://localhost:4200
- .NET Swagger: http://localhost:8080/swagger
- ML API docs: http://localhost:8000/docs

Use **Simulate Incident** in the dashboard to generate a demo incident.

## Architecture
```text
Angular Dashboard
       |
ASP.NET Core API ---- SQL Server
       |
Python ML Service
       |
Isolation Forest
```

## ML
The demo ML service trains an Isolation Forest on generated normal telemetry. It evaluates latency, HTTP 5xx rate, and database failures. This is a demonstration model, not a production reliability or root-cause system.

## AWS extension
The API boundary is designed so simulated telemetry can later be replaced with AWS CloudWatch metrics. A future version can use CloudWatch, Lambda, SNS, S3, IAM, and RDS.

## Security improvements
For production use, add JWT/RBAC, HTTPS, managed secrets, restricted CORS, dependency scanning, SAST/DAST, audit logging, and rate limiting.

## License
MIT
