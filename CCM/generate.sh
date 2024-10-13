#!/bin/zsh
source .env
dotnet  ef -f net6.0 dbcontext scaffold "Server=${DB_HOST};Database=${DB_NAME};Uid=${DB_USER};Pwd=${DB_PASSWORD};" Pomelo.EntityFrameworkCore.MySql -o Models

