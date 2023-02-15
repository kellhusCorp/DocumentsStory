# Documents Story

Приложение является реализацией клиент-серверного приложения при поддержке WCF.

## Технологии

- [.NET Framework 4.8.1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481)
- [WCF](https://learn.microsoft.com/ru-ru/dotnet/framework/wcf/whats-wcf)
- [Entity Framework 6.4.4](https://learn.microsoft.com/ru-ru/ef/ef6/what-is-new/)
- [Microsoft® SQL Server® 2019 Express](https://www.microsoft.com/ru-RU/download/details.aspx?id=101064)
- [JetBrains Rider](https://www.jetbrains.com/ru-ru/rider/)
- [Visual Studio 2022 Community](https://visualstudio.microsoft.com/ru/vs/)

## Подготовка БД

`Первый вариант`, воспользоваться применением миграции, для этого из-под сборки ./DocumentsStory.Data/, используем <strong>Package Manager Console (VS)</strong>:

```
PM> Update-Database -ConnectionString "data source=localhost\SQLEXPRESS01;initial catalog=DocumentsDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" -ConnectionProviderName "System.Data.SqlClient" -Verbose
```

где <strong>ConnectionString</strong> - строка подключения к Sql Express, точно такая же какая будет использоваться, для старта `DocumentsStory.Server` - ./DocumentsStory.Server/App.config.

`Второй вариант`, без <strong>Package Manager Console (VS)</strong>:
```
<path_to_general_dir>\DocumentsStory\packages\EntityFramework.6.4.4\tools\net45\any\ef6.exe database update --connection-string "data source=localhost\SQLEXPRESS01;initial catalog=DocumentsDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" --connection-provider System.Data.SqlClient --verbose --no-color --prefix-output --assembly <path_to_general_dir>\DocumentsStory\DocumentsStory.Data\bin\Debug\DocumentsStory.Data.dll --project-dir <path_to_general_dir>\DocumentsStory\DocumentsStory.Data\ --language C# --root-namespace DocumentsStory.Data --config <path_to_general_dir>\DocumentsStory\DocumentsStory.Data\App.config
```

`Третий вариант`, выполнение скриптов вручную:

- Выполнить `./SqlQueries/CreateStructure.sql `
- Выполнить `./SqlQueries/InsertTestDocuments.sql`

## Запуск приложения

1. Необходимо настроить адрес размещения сервера и строку подключения к БД в конфиге `./DocumentsStory.Server/App.config`, <i>hostAddress</i> и <i>DefaultConnection</i> соответственно.
2. Необходимо настроить адрес сервера, со стороны клиента в конфиге `./DocumentsStory.Client/App.config`. 
3. По-умолчанию, везде используется 5000 порт.
4. Первым запускается <strong>DocumentsStory.Server</strong>, затем <strong>DocumentsStory.Client</strong>.