# Calculadora de Aposentadoria
<h3>Obs! O seguinte projeto está configurado para rodar em container</h3>

<h4>Comandos:</h4>

<h4>-Na pasta da api rode o seguinte comando:</h4>
<h4>docker build -t [dê um nome para a imagem] .</h4>

<h4>-Dps, vá na pasta do front e rode o mesmo comando anterior</h4>

<h4>-após buildar as duas imagens você pode rodar os containers a partir de qualquer diretório.</h4>

<h4>-Para a api use o comando:</h4>
<h4>docker run --name [dê um nome para o contâiner] -e ASPNETCORE_ENVIRONMENT="Development" -e ASPNETCORE_URLS="http://0.0.0.0:5000" -p 5000:5000 [nome da imagem que você deu]</h4>

<h4>-Para rodar o front use o comando:</h4>
<h4>docker run --name [dê um nome para o contâiner] -d -p 4200:80 [nome da imagem que você deu]</h4>
