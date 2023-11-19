# cd src/infrastructure
Start-Process powershell -ArgumentList "wt -d ./"

cd .\DomainCentricDemo.Api
Start-Process powershell -ArgumentList "dapr run --app-id bookdemoapi --app-port 5103 --dapr-http-port 32000 --dapr-grpc-port 3800 -- dotnet run"

cd ..\DemoApi
Start-Process powershell -ArgumentList "dapr run --app-id weatherdemoapi --app-port 5277 --dapr-http-port 31000 --dapr-grpc-port 3700 -- dotnet run"

cd ..\DomainCentricDemo.Web
Start-Process powershell -ArgumentList "dapr run --app-id bookdemoweb --app-port 5039 --dapr-http-port 30000 --dapr-grpc-port 3600 -- dotnet run"

cd ..\
Start-Process "http://localhost:9411/zipkin/"
Start-Process "http://localhost:5039/"

pause


