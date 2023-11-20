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

https://medium.com/@__hungrywolf/microservices-pub-sub-with-dapr-docker-compose-and-net-1e5be05ada1a

https://github.com/johnseed/dapr-pubsub-demo/blob/master/docker-compose.yml

http://localhost:30000/Book

# Local Development
dapr run --app-id bookdemoapi --app-port 5103 --dapr-http-port 32000
dapr run --app-id weatherdemoapi --app-port 5277 --dapr-http-port 31000
dapr run --app-id bookdemoweb --app-port 5039 --dapr-http-port 30000


dapr invoke --app-id bookdemoapi  --verb GET -m api/book
dapr invoke --app-id weatherdemoapi  --verb GET -m weatherforecast

https://medium.com/@__hungrywolf/microservices-pub-sub-with-dapr-docker-compose-and-net-1e5be05ada1a
