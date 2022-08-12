# Build
FROM node:14 AS build
WORKDIR /usr/src/app
COPY package.json ./
RUN npm i
COPY . .
RUN npm run build

# Run
FROM nginx:1.17.1-alpine
COPY --from=build /usr/src/app/dist/frontend /usr/share/nginx/html
EXPOSE 80