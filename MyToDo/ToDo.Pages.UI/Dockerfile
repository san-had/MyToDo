#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ToDo.Pages.UI/ToDo.Pages.UI.csproj", "ToDo.Pages.UI/"]
COPY ["ToDo.Module/ToDo.Module.csproj", "ToDo.Module/"]
COPY ["ToDo.Domain/ToDo.Domain.csproj", "ToDo.Domain/"]
COPY ["ToDo.Extensibility/ToDo.Extensibility.csproj", "ToDo.Extensibility/"]
COPY ["ToDo.Service/ToDo.Service.csproj", "ToDo.Service/"]
RUN dotnet restore "ToDo.Pages.UI/ToDo.Pages.UI.csproj"
COPY . .
WORKDIR "/src/ToDo.Pages.UI"
RUN dotnet build "ToDo.Pages.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDo.Pages.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo.Pages.UI.dll"]