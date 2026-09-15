from fastapi import FastAPI
from pydantic import BaseModel
from sklearn.ensemble import IsolationForest
import numpy as np

app=FastAPI(title="SentinelFlow ML",version="1.0")
rng=np.random.default_rng(42)
normal=np.column_stack([
    rng.normal(230,35,500),
    np.clip(rng.normal(.4,.25,500),0,None),
    np.clip(rng.normal(.2,.2,500),0,None)
])
model=IsolationForest(contamination=.04,random_state=42).fit(normal)

class Metrics(BaseModel):
    latencyMs: float
    http5xxRate: float
    dbFailures: float

@app.get("/health")
def health(): return {"status":"ok"}

@app.post("/detect")
def detect(m:Metrics):
    x=[[m.latencyMs,m.http5xxRate,m.dbFailures]]
    prediction=int(model.predict(x)[0])
    score=float(-model.decision_function(x)[0])
    return {"isAnomaly":prediction==-1,"anomalyScore":round(score,4)}
