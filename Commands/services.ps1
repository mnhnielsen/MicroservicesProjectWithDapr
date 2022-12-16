#Order Service Deploy
dapr run --app-id "order-service" --app-port "5001" --dapr-grpc-port "50010" --dapr-http-port "5010" --components-path "./components" -- dotnet run --project ./sample.microservice.service1/sample.microservice.service1.csproj --urls="http://+:5001"
#Order Service Request
dapr publish --publish-app-id order-service --pubsub commonpubsub -t On_Order_Stored  -d '{\"OrderId\": \"34490b68-c361-4eec-aff1-5d272fe387fe\"}'



#Shipping Service Deploy
dapr run --app-id "shipping-service" --app-port "5005" --dapr-grpc-port "50050" --dapr-http-port "5050" --components-path "./components" -- dotnet run --project ./sample.microservice.service2/sample.microservice.service2.csproj --urls="http://+:5005"
#Shipping Service Request
dapr publish --publish-app-id shipping-service --pubsub commonpubsub -t OnOrder_Prepared -d '"{\"OrderId\": \"54490b69-c361-4eec-aff1-5d272fe387fe\"}"'