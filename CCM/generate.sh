#!/bin/zsh
source .env
dotnet ef dbcontext scaffold "Server=${DB_HOST};Database=${DB_NAME};Uid=${DB_USER};Pwd=${DB_PASSWORD};" Pomelo.EntityFrameworkCore.MySql -o Models

