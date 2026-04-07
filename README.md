# RepairIS
Информационная система ремонтного предприятия (курсовая работа)
# RepairIS — Информационная система ремонтного предприятия

[![C#](https://img.shields.io/badge/C%23-12.0-blue)](https://dotnet.microsoft.com/)
[![.NET](https://img.shields.io/badge/.NET-4.8-purple)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
[![Windows Forms](https://img.shields.io/badge/Windows-Forms-0078D4)](https://github.com/dotnet/winforms)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

**RepairIS** — это desktop-приложение для автоматизации работы ремонтного предприятия. Система позволяет управлять полным циклом ремонта станков: от подачи заявки клиентом до фиксации результата мастером и формирования сметы.

## 🚀 Возможности

- **Три роли пользователей:** Заказчик, Менеджер, Мастер
- **Создание и отслеживание заявок** на ремонт
- **Назначение мастеров** менеджером
- **Формирование и подтверждение сметы**
- **Фиксация осмотра и статуса ремонта** мастером
- **История изменений** по каждой заявке
- **Хранение данных в JSON** (не требует установки СУБД)

## 📋 Системные требования

- Windows 7 / 8 / 10 / 11
- [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48) (обычно уже установлен в Windows 10/11)
- Visual Studio 2022 (только для разработки, опционально)
## 🛠️ Технологии

- **Язык:** C# 7.3 / 8.0
- **Платформа:** .NET Framework 4.8
- **UI:** Windows Forms
- **Хранение данных:** JSON + Newtonsoft.Json (Json.NET)
- **Тестирование:** xUnit.net

## 📄 Лицензия

MIT License. Подробнее в файле [LICENSE](LICENSE).

## 👩‍💻 Автор

**Д. В. Фролова**  
Группа КИ24-20Б, СФУ  
Красноярск, 2026


Руководитель: В. С. Васильев  
Кафедра прикладной информатики, ИКИТ, СФУ
## 🔧 Установка и запуск

### Для пользователей

1. Скачайте исходный код: нажмите зелёную кнопку **"Code"** → **"Download ZIP"**
2. Распакуйте архив в любую папку
3. Откройте папку `RepairIS/bin/Debug/` (или `Release`)
4. Запустите `RepairIS.exe`

> **Примечание:** Если папки `bin/Debug` нет, нужно сначала собрать проект (см. раздел "Для разработчиков").

### Для разработчиков

```bash
git clone https://github.com/fqrfqrshow/RepairIS.git
cd RepairIS
