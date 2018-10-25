COMPOSE = docker-compose -f asset-register-api/docker-compose.yml

.PHONY: docker-build
docker-build:
	$(COMPOSE) build

.PHONY: docker-down
docker-down:
	$(COMPOSE) down

.PHONY: serve
serve:	docker-down docker-build
	$(COMPOSE) up

.PHONY: test
test:
	docker build --pull --target testrunner -t asset-register-api:test .
	docker run --rm asset-register-api:test
