FROM registry.mprn.mp.br:5000/base-dotnetcore:v5.0-1.0.0

WORKDIR /opt/app-root/src/

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o /opt/app-root/app/

WORKDIR /opt/app-root/app/

RUN dotnet dev-certs https

ENTRYPOINT dotnet MPRN.CalculadoraAposentadoria.WebApi.dll