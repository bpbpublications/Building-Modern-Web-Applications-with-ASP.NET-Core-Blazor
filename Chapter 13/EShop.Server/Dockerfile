FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /app

COPY . ./

RUN dotnet restore \
    && dotnet publish ./EShop.Server.csproj -o /blazor/

WORKDIR /blazor

ENV ASPNETCORE_URLS="http://0.0.0.0:5000"

ENTRYPOINT ["dotnet", "EShop.Server.dll"]