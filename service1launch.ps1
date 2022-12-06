dapr run --app-id "order-service" --app-port "5000" --dapr-grpc-port "50050" --dapr-http-port "5050" --components-path "./components" -- dotnet run --project ./sample.microservice.service1/sample.microservice.service1.csproj --urls="http://+:5001"

dapr publish --publish-app-id order-service --pubsub commonpubsub -t On_Order_Stored  -d '{\"OrderId\": \"34490b68-c361-4eec-aff1-5d272fe387fe\"}'