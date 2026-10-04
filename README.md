# RepairIS — Информационная система ремонтного предприятия

[![C#](https://img.shields.io/badge/C%23-12.0-blue)](https://dotnet.microsoft.com/)
[![.NET](https://img.shields.io/badge/.NET-4.8-purple)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
[![Windows Forms](https://img.shields.io/badge/Windows-Forms-0078D4)](https://github.com/dotnet/winforms)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

**RepairIS** — информационная система для автоматизации учёта заявок на ремонт
станков на ремонтном предприятии. Система решает проблему разрозненного
учёта заявок и отсутствия прозрачного контроля их выполнения: позволяет
заказчикам подавать заявки, менеджерам — назначать мастеров и формировать
сметы, а мастерам — фиксировать результаты осмотра и ремонта. Результат —
единая база заявок с историей изменений и статусами, доступная всем ролям
пользователей.

---

## 👥 Участники команды

| Участник | Роль | Обязанности |
|----------|------|-------------|
| Фролова Д. В. | Аналитик | Сбор и формализация требований, моделирование бизнес-процессов |
| Фролова Д. В. | Разработчик | Реализация форм, бизнес-логики, слоя данных |
| Фролова Д. В. | Архитектор | Выбор технологического стека, проектирование структуры |
| Фролова Д. В. | Тестировщик | Разработка тестов (xUnit), проверка сценариев |
| Фролова Д. В. | Руководитель проекта | Планирование, контроль сроков, управление рисками |
| Фролова Д. В. | Специалист по развёртыванию | Настройка сборки, подготовка релизов |

> Роли совмещаются одним участником в рамках курсового проекта.

---

## 🚀 Возможности

- **Три роли пользователей:** Заказчик, Менеджер, Мастер
- **Создание и отслеживание заявок** на ремонт
- **Назначение мастеров** менеджером
- **Формирование и подтверждение сметы**
- **Фиксация осмотра и статуса ремонта** мастером
- **История изменений** по каждой заявке
- **Хранение данных в JSON** (не требует установки СУБД)

---

## 🏗️ Архитектура

RepairIS — **desktop-приложение** на C# (Windows Forms) с хранением данных в **JSON-файлах**.

Архитектура построена на паттернах **Adapter** и **Facade** и разделена на 4 слоя:

1. **UI (Windows Forms)** — формы приложения
2. **Business Logic (RequestSystemFacade)** — координация операций, каскадные изменения
3. **Data Access (Adapters)** — работа с JSON-файлами (OrderAdapter, RequestAdapter, InspectionAdapter, EstimateAdapter, MasterAdapter)
4. **Storage (JSON)** — файлы данных (orders.json, users.json, machines.json, estimates.json, inspections.json, masters.json)

**Преимущества выбранной архитектуры:**
- Слабая связанность слоёв
- Лёгкость тестирования
- Возможность перехода на СУБД без переписывания бизнес-логики

Подробнее: [docs/architecture/components.md](docs/architecture/components.md)

---

## 🛠️ Технологический стек

| Категория | Инструмент |
|-----------|-----------|
| Язык программирования | C# 7.3 / 8.0 |
| Платформа | .NET Framework 4.8 |
| UI | Windows Forms |
| Хранение данных | JSON + Newtonsoft.Json (Json.NET) |
| Тестирование | xUnit.net |
| IDE | Visual Studio 2022 |
| Система контроля версий | Git + GitHub |
| Трекер задач | GitHub Issues + Projects |
| Инструмент моделирования | draw.io, PlantUML |
| Клиент для тестирования API | Postman |
| Средство контейнеризации | Docker |

---

## 📁 Документация

### 📊 Анализ предметной области (BPMN)

| Файл | Описание |
|------|----------|
| [docs/bpmn/as_is.md](docs/bpmn/as_is.md) | Описание текущего (As-Is) процесса |
| [docs/bpmn/to_be.md](docs/bpmn/to_be.md) | Описание целевого (To-Be) процесса |
| [docs/bpmn/to_be.png](docs/bpmn/to_be.png) | BPMN-диаграмма целевого процесса |

### 📋 Требования

| Файл | Описание |
|------|----------|
| [docs/requirements/functional.md](docs/requirements/functional.md) | Функциональные требования |
| [docs/requirements/non_functional.md](docs/requirements/non_functional.md) | Нефункциональные требования (NFR) |

### 🏛️ Архитектура (C4 Model)

| Файл | Описание |
|------|----------|
| [docs/architecture/context_diagram.png](docs/architecture/context_diagram.png) | C4 Level 1 — Контекстная диаграмма |
| [docs/architecture/containers_diagram.png](docs/architecture/containers_diagram.png) | C4 Level 2 — Диаграмма контейнеров |
| [docs/architecture/components.md](docs/architecture/components.md) | Описание компонентов системы |

### 🗄️ Модель данных

| Файл | Описание |
|------|----------|
| [docs/data/er_diagram.png](docs/data/er_diagram.png) | ER-диаграмма |
| [docs/data/er_diagram.md](docs/data/er_diagram.md) | Описание модели данных + нормализация 3НФ |

### 📝 Архитектурные решения (ADR)

| Файл | Описание |
|------|----------|
| [docs/adr/001_architecture_style.md](docs/adr/001_architecture_style.md) | ADR-001: выбор архитектурного стиля (монолит) |
| [docs/adr/002_database_choice.md](docs/adr/002_database_choice.md) | ADR-002: выбор хранилища данных (JSON вместо СУБД) |

---

## 🔗 Ссылки

- **Репозиторий:** https://github.com/fqrfqrshow/RepairIS
- **Трекер задач:** https://github.com/fqrfqrshow/RepairIS/issues
- **Доска проекта:** https://github.com/fqrfqrshow/RepairIS/projects

---

## 📋 Системные требования

- Windows 7 / 8 / 10 / 11
- [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48) (обычно уже установлен в Windows 10/11)
- Visual Studio 2022 (только для разработки, опционально)

---

## 🔧 Установка и запуск

### Для пользователей

1. Скачайте исходный код: нажмите зелёную кнопку **"Code"** → **"Download ZIP"**
2. Распакуйте архив в любую папку
3. Откройте папку `RepairIS/bin/Debug/` (или `Release`)
4. Запустите `RepairIS.exe`

> **Примечание:** Если папки `bin/Debug` нет, нужно сначала собрать проект (см. раздел "Для разработчиков").

### Для разработчиков

1. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/fqrfqrshow/RepairIS.git
   cd RepairIS
   ```
2. Откройте файл `RepairIS.sln` в Visual Studio 2022.
3. Соберите решение: **Build → Build Solution** (или `Ctrl+Shift+B`).
4. Запустите проект: **F5** или зелёная кнопка **Start**.

### Учётные данные

При первом запуске автоматически создаётся файл `users.json` с учётной записью менеджера:
- **Логин:** `manager`
- **Пароль:** `manager`
- **Роль:** Менеджер

Для ролей «Мастер» и «Заказчик» необходимо зарегистрироваться через форму регистрации или добавить пользователей вручную в `users.json`.

---

## 🧪 Тестирование

Проект покрыт модульными тестами (xUnit.net):
- **Всего тестов:** 12
- **Покрытие кода:** 89%
- **Все тесты пройдены:** ✅

Запуск тестов: в Visual Studio → **Test Explorer → Run All Tests**.

---

## 📊 Статус проекта

- ✅ Анализ предметной области (As-Is / To-Be)
- ✅ BPMN-диаграмма целевого процесса
- ✅ Функциональные и нефункциональные требования
- ✅ Архитектура (C4 Level 1 и Level 2)
- ✅ Модель данных (ER-диаграмма, 3НФ)
- ✅ Архитектурные решения (ADR)
- ✅ Реализация на C# (Windows Forms)
- ✅ Модульное тестирование (89% покрытия)

---

## 👩‍💻 Автор

**Диана Владимировна Фролова**
Группа КИ24-20Б, СФУ
Красноярск, 2026

---

<!-- Связано с задачей #1 -->
