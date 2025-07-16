# crear solucion
dotnet new sln --name Seguridad

# crear proyectos
dotnet new classlib --name Abstracciones
dotnet new classlib --name BW
dotnet new classlib --name BC
dotnet new classlib --name DA
dotnet new webapi --use-controllers --name API

# agreagar a la solucion
dotnet sln add Abstracciones/Abstracciones.csproj
dotnet sln add BW/BW.csproj
dotnet sln add BC/BC.csproj
dotnet sln add DA/DA.csproj
dotnet sln add API/API.csproj