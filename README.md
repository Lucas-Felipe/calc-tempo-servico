# Calculadora de Aposentadoria
Obs! O seguinte projeto está configurado para rodar em container

Comandos:

-Na pasta da api rode o seguinte comando: \n
docker build -t [dê um nome para a imagem] .

-Dps, vá na pasta do front e rode o mesmo comando anterior

-após buildar as duas imagens você pode rodar os containers a partir de qualquer diretório.

-Para a api use o comando: \n
docker run --name [dê um nome para o contâiner] -e ASPNETCORE_ENVIRONMENT="Development" -e ASPNETCORE_URLS="http://0.0.0.0:5000" -p 5000:5000 [nome da imagem que você deu]

-Para rodar o front use o comando:\n
docker run --name [dê um nome para o contâiner] -d -p 4200:80 [nome da imagem que você deu]
