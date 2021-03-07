up:
	docker-compose up --build

test:
	dotnet test

coverage:
	dotnet test --collect:"XPlat Code Coverage"

lint:
	dotnet format --check