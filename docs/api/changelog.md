# Changelog API

## [1.0.0] — 2026-11-24
### Added
- Первая версия контракта OpenAPI 3.0.
- Ресурсы: /users, /requests, /machines, /inspections, /estimates.
- Вложенные ресурсы: /requests/{id}/estimate, /requests/{id}/inspections.
- Аутентификация JWT (Bearer).
- Единая модель ошибок RFC 9457 (application/problem+json).
- Пагинация и фильтрация списков.
