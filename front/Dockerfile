FROM node:14.18.1 as angular

WORKDIR /app

COPY package.json /app/

RUN npm install

COPY . /app

RUN npm i -g @angular/cli

RUN npm run build

FROM nginx

VOLUME /var/chache/nginx

COPY --from=angular /app/dist/CalculadoraFrontEnd /usr/share/nginx/html
