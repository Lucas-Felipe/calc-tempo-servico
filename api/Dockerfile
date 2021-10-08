FROM mcr.microsoft.com/dotnet/sdk

WORKDIR /opt/app-root/src/

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o /opt/app-root/app/

WORKDIR /opt/app-root/app/

RUN dotnet dev-certs https

ENTRYPOINT dotnet MPRN.CalculadoraAposentadoria.WebApi.dll