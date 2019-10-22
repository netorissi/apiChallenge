FROM microsoft/dotnet:2.2-aspnetcore-runtime

LABEL version="1.0" maintainer="Neto Rissi"

WORKDIR /app

# Copiar dist
COPY ./dist .

ENTRYPOINT [ "dotnet", "Poll_Challenge_Api.dll" ]