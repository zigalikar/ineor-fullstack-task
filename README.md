### Run
Run the project with the following command while in the repository root:

    docker-compose up

Frontend should then be accessible at http://localhost:80, API at http://localhost:5001 and database at http://localhost:3306.
Swagger documentation is available at http://localhost:5001/swagger/index.html (enabled also in production configuration)

The project is also hosted live at ....

#### Frontend
Frontend can be ran separately in a development environment by navigating to the `./frontend` folder and running it:

    cd frontend && npm run start

Frontend expects an API at `http://localhost:5001/api`.

#### Backend
Backend can be ran separately in a development environment by navigating to the `./IneorTaskBackend/IneorTaskBackend` folder and running it:

    cd IneorTaskBackend/IneorTaskBackend && dotnet run

Backend expects an MySQL database at `http://localhost:3306`.

#### MySQL database
I ran an MySQL container with Docker for development purposes on port `3306`.

### Summary
Frontend part is created in Angular in the folder `./frontend`.
Backend part is created in .NET Core in the folder `./IneorTaskBackend`.
Data is stored in an `MySQL` database and prepopulated/seeded with data.
Hosted on HTTP.

#### Domain
The domain of the task are beaches. The page shows a list of beaches with details with a search query and a sort function. Items can be added, removed, edited, and are stored in a MySQL database.

#### Technicalities
Internationalization is achieved with i18n - currently two languages are support: SL and EN. Language can be changed from the dropdown menu in the top right.
Edit, create and delete endpoints on the backend require authentication - delete also requires authorization with an admin role. You can login as a user on the frontend from the dropdown menu in the top right.
Unit tests on the backend are done with `XUnit` in the project `IneorTaskBackend.Tests` and with `jest` on the frontend.

Two users are pre-generated:

**username**: user
**password**: user
**role**: /

**username**: admin
**password**: admin
**role**: admin

Two environments are setup on both frontend and backend: `development` and `production`. By running locally, development is selected; Dockerfile builds the projects in the production environment so Docker containers are run as on production.

Data is cached on the frontend with `NgRx` and local storage (to persist user login).

Exceptions are handled with Sentry on both frontend and backend (to different DSNs - both development and production still use the same DSN though).

Branching strategy is visible on this repository (adding a feature).

### Further improvement ideas
Things that could be improved upon:
* HTTPS
* localization for content (entries in the DB for SL and EN languages)
* detail page for each item (to make use of the `GET beaches/{id}` endpoint)
* separate Sentry logs for production and development (and other environments)
