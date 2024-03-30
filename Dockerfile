# SDK image'ını kullanarak build aşamasını başlatın
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Kaynak kodu container'a kopyalayın
COPY PerformanceBottleneckApp.cs ./

# Proje dosyası oluşturun ve uygulamayı build edin
RUN dotnet new console -n PerformanceBottleneckApp --force && \
    mv PerformanceBottleneckApp.cs PerformanceBottleneckApp/Program.cs && \
    dotnet publish -c Release -o out /app/PerformanceBottleneckApp

# Runtime image'ı hazırlayın
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PerformanceBottleneckApp.dll"]
CMD ["cpu"] # Varsayılan olarak "cpu" darboğazı oluştur
