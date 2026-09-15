# SentinelFlow AI

SentinelFlow AI is a small incident monitoring project that I built to detect unusual application behavior and display incident details in a dashboard.

The application uses a .NET Web API for the backend, Angular for the frontend, SQL Server for storing incident data, and a Python service for anomaly detection.

## Features

- Monitor application metrics
- Detect unusual behavior using machine learning
- Generate sample incidents for testing
- View incident details and severity
- Store incident history
- View suggested troubleshooting steps

## Technologies Used

- C#
- .NET 8
- ASP.NET Core Web API
- Angular
- TypeScript
- Python
- scikit-learn
- SQL Server
- Entity Framework Core
- Docker
- Swagger
- GitHub Actions

## Project Structure

```text
backend/       ASP.NET Core Web API
frontend/      Angular application
ml-service/    Python ML service
.github/       GitHub Actions workflow
```

## Running the Project

Make sure Docker Desktop is running.

Clone the repository:

```bash
git clone https://github.com/jhansi2415/SentinelFlow-AI.git
cd SentinelFlow-AI
```

Create the environment file from `.env.example`.

Then run:

```bash
docker compose up --build
```

After the containers start:

- Frontend: `http://localhost:4200`
- Swagger API: `http://localhost:8080/swagger`
- ML Service: `http://localhost:8000/docs`

## Machine Learning

The Python service uses scikit-learn and Isolation Forest to identify unusual application metrics such as response time, HTTP errors, and database failures.

The current model uses generated sample data and is intended for project/demo purposes.
