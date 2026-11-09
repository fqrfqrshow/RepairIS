# Миграция 001. Создание начальных файлов

## Описание
Создание пустых JSON-файлов с базовой структурой при первом запуске приложения.

## Файлы
- `users.json` → `[]`
- `machines.json` → `[]`
- `masters.json` → `[]`
- `orders.json` → `[]`
- `inspections.json` → `[]`
- `estimates.json` → `[]`
- `status_history.json` → `[]`

## Код (C#)
```csharp
if (!File.Exists(path))
{
    File.WriteAllText(path, "[]");
}
