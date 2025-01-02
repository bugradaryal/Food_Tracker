# NourishTrack

NourishTrack is a web application that helps users track their meals, receive notifications about their expiration dates, promote healthy eating, and reduce food waste. Users can save their meals in personalized lists and track their freshness over time with notifications.

## Technologies Used

- **MVC Application**: ASP.NET Core MVC
- **Frameworks**: Hangfire, MailKit, SignalR, Entity Framework Core, Identity, Logging, MimeKit, Newtonsoft.Json, Object Comparer, SMS API
- **Authentication**: JWT (JSON Web Tokens)
- **Database**: SQL Server (or another preferred database)
- **Database Method**: Code First (using Entity Framework Core for Code First approach)

## Migration Process

1. **Create a New Migration**:
    ```bash
    dotnet ef migrations add MigrationName
    ```

2. **Update the Database**:
    ```bash
    dotnet ef database update
    ```

**Note**: The database connection is configured within the `DbContext` class.

## Getting Started

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/NourishTrack.git
    ```

2. Install dependencies:
    ```bash
    dotnet restore
    ```

3. Run the MVC application:
    ```bash
    dotnet run
    ```

