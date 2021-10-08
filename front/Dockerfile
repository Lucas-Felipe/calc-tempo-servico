FROM node:latest as angular

WORKDIR /app

COPY package.json /app/

RUN npm install

COPY . /app

RUN npm run build

FROM nginx

VOLUME /var/chache/nginx

# RUN rm -rf /usr/share/nginx/html/*

COPY --from=angular /app/dist/CalculadoraFrontEnd /usr/share/nginx/html
