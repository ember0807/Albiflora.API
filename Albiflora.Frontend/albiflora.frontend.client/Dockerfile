# Сборка статики React через Vite
FROM node:20-alpine AS build-stage
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Раздача готовой статики через Nginx веб-сервер
FROM nginx:stable-alpine
COPY --from=build-stage /app/dist /usr/share/nginx/html

# Конфиг, чтобы работал React Router (перенаправление путей)
RUN echo 'server { listen 80; location / { root /usr/share/nginx/html; index index.html; try_files $uri $uri/ /index.html; } }' > /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]