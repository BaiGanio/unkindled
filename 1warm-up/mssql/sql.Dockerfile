# THIS IS PURE STANDALONE SQL SERVER

# Use official SQL Server image
FROM mcr.microsoft.com/mssql/server:2022-latest

# Set required environment variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=P@ssw0rd

# Expose SQL Server port different from default 1433
EXPOSE 1434

# Default command to run SQL Server
CMD ["/opt/mssql/bin/sqlservr"]