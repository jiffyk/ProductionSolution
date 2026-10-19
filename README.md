# Разработка библиотеки классов (C#)

- `WSUniversalLib` — библиотека (`WSUniversalLib.dll`), класс `Calculation`, метод `GetQuantityForProduct(int productType, int materialType, int count, float width, float length)`.
- `CoreLib` — библиотека (`CoreLib.dll`), класс `Utils`, метод `GenerateOrderNumber(Client client, DateTime dateTime)`.
- `ProductionApp` — консольное приложение, использующее обе библиотеки.

## Сборка и запуск
    dotnet build -c Release
    dotnet run --project ProductionApp

## Git: отдельные репозитории
Задание требует отдельный репозиторий для каждой библиотеки, с именем, совпадающим с названием проекта:

    cd WSUniversalLib && git init && git add . && git commit -m "WSUniversalLib" && cd ..
    cd CoreLib        && git init && git add . && git commit -m "CoreLib" && cd ..

и затем `git remote add origin <url>` / `git push -u origin main` для каждого.
