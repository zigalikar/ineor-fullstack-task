# For deploying Docker containers to Heroku
# If building on Mac (ARM chip) the platform has to be set explicitly in order for the images to run on Heroku

# Heroku app
APP_API=ineor-fullstack-task
APP_FE=ineor-fullstack-task-frontend

# building and deploying the API
cd IneorTaskBackend
docker buildx build --platform linux/amd64 -t $APP_API .
docker tag $APP_API registry.heroku.com/$APP_API/web
docker push registry.heroku.com/$APP_API/web
heroku container:release web --app $APP_API

# building and deploying frontend
cd ../frontend
docker buildx build --platform linux/amd64 -t $APP_FE .
docker tag $APP_FE registry.heroku.com/$APP_FE/web
docker push registry.heroku.com/$APP_FE/web
heroku container:release web --app $APP_FE

# open logs for API
heroku logs --tail --app $APP_API