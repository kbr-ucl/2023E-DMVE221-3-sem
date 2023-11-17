https://learn.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/getting-started



https://learn.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/service-invocation

dapr invoke --app-id bookservice  --verb GET -m api/book

curl -H @{"dapr-app-id"="weatherservice"} http://localhost:45000

https://johnnyreilly.com/azure-container-apps-dapr-bicep-github-actions-debug-devcontainer





http://localhost:45000/v1.0/invoke/weatherservice/method/WeatherForecast



dapr invoke --app-id weatherservice  --verb GET -m weatherforecast



https://docs.dapr.io/reference/cli/dapr-run/





```
http://localhost:45000/v1.0/invoke/weatherdemoapi/method/weatherforecast
```