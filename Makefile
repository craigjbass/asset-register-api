COMPOSE = docker-compose -f hear-api/docker-compose.yml

.PHONY: docker-build
docker-build:
	$(COMPOSE) build

.PHONY: docker-down
docker-down:
	$(COMPOSE) down

.PHONY: serve
serve:	docker-down docker-build
	$(COMPOSE) up
