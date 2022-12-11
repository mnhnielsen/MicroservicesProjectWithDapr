FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["sample.microservice.common/sample.microservice.common.csproj", "sample.microservice.common/"]
COPY ["sample.microservice.dto.shipment/sample.microservice.dto.shipment.csproj", "sample.microservice.dto.shipment/"]
COPY ["sample.microservice.dto.order/sample.microservice.dto.order.csproj", "sample.microservice.dto.order/"]
COPY ["sample.microservice.service1/sample.microservice.service1.csproj", "sample.microservice.service1/"]
RUN dotnet restore "sample.microservice.common/sample.microservice.common.csproj"
RUN dotnet restore "sample.microservice.dto.shipment/sample.microservice.dto.shipment.csproj"
RUN dotnet restore "sample.microservice.dto.order/sample.microservice.dto.order.csproj"
RUN dotnet restore "sample.microservice.service1/sample.microservice.service1.csproj"
COPY . .
WORKDIR "/src/sample.microservice.service1"
RUN dotnet publish "sample.microservice.service1.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "sample.microservice.service1.dll"]