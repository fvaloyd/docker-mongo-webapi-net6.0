# Webapi ASP.NET, Mongodb & Docker

## Steps for run the api
### Build the App image
```
docker build -t webapi-mongo:v2 .
```
### Run the network with docker-compose
```
docker-compose up
```
>>>The webapi container is listening in https://localhost:8080
