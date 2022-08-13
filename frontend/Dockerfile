FROM node:14 AS build
ENV ENVIRONMENT=production
WORKDIR /usr/src/app
COPY package.json ./
RUN npm i
COPY . .
RUN npm run build:$ENVIRONMENT

FROM nginx:1.17.1-alpine
COPY --from=build /usr/src/app/dist/frontend /usr/share/nginx/html
COPY ./nginx/default.conf.template /etc/nginx/conf.d/default.conf
CMD sed -i -e 's/$PORT/'"$PORT"'/g' /etc/nginx/conf.d/default.conf && nginx -g 'daemon off;'
