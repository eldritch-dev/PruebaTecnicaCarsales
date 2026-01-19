# PruebaTecnicaCarsales
Backend for Frontend API.

# Consideraciones previas
1. El proyecto usa ASP.NET Core 8.0 y fue escrito y probado en Visual Studio Code.
2. Si no tiene Visual Studio Code, descargar e instalar desde https://code.visualstudio.com/download.
3. Si no las tiene, instalar las siguientes dependencias en Visual Studio Code.
    3.1. .NET Install Tool
    3.2. C# Dev Kit
4. Si no lo tiene, descargar e instalar .NET SDK 9.0.308 https://dotnet.microsoft.com/es-es/download/dotnet/9.0.
5. Si no lo tiene, descargar e instalar ASP.NET Core Runtime 8.0.22 desde https://dotnet.microsoft.com/en-us/download/dotnet/8.0.

# Instrucciones para probar el proyecto
1. En terminal git bash o powershell ejecutar "dotnet run".
2. Al terminar de revisar el proyecto, detener servidor con "Ctrl+c" en la terminal.

# Endpoints base
1. Para que el frontend pueda consumir recursos: http://localhost:5208/
2. Para revisar en Swagger UI en el navegador, si es que no se abre automáticamente: http://localhost:5208/swagger

# Detalles
1. El proyecto se ha implementado utilizando arquitectura vertical, la que me ha parecido la más idonea considerando el tiempo acotado y la facilidad de comprensión de quienes quieran revisar el código.
2. Expone 2 endpoints principales ("/episodes" y "/characters"), 2 endpoints para levantar errores ("/implicit-error" y "explicit-error") y 1 endpoint para las sugerencias del buscador del frontend ("/characters/search").
3. Ambos endpoints de error se pueden probar en Swagger, pero desde el frontend, el botón para probar error está conectado al error explícito.