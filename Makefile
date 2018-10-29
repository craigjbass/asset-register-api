COMPOSE = docker-compose -f asset-register-api/docker-compose.yml

.PHONY: test setup serve build docker-build docker-down shell

test:
	docker build --pull --target testrunner -t asset-register-api:test .
	docker run --rm asset-register-api:test

setup: build

serve: docker-down docker-build
	$(COMPOSE) up

build: docker-build

docker-build:
	$(COMPOSE) build

docker-down:
	$(COMPOSE) down

shell:
	$(COMPOSE) run --rm web /bin/bash
