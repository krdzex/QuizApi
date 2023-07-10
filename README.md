# QuizApi

## Overview
QuizApi is a backend service designed to support a quiz-based frontend application. It allows the creation, retrieval, updating, and deletion of quizzes. Each quiz consists of multiple questions, each having a corresponding answer. Notably, quizzes can share questions, allowing for reusability and efficient data management.

## Key Features
1. **Quizzes Retrieval**: Retrieve quizzes based on quiz name, with pagination to efficiently manage large question collections.
2. **Quiz Retrieval**: Get quizz with question.
3. **Quiz Update**: Change the name of any quiz.
4. **Quiz Deletion**: Remove quizzes without deleting the associated questions, preserving them for other quizzes.
5. **Quiz Creation**: Create a new quiz with a name, new questions, and questions taken from existing quizzes.
6. **Question Update**: Modify content of question.
7. **Questions Retrieval**: Retrieve questions based on their text, with pagination to efficiently manage large question collections.
8. **Remove question from quiz**: Remove question from quiz if question exist in that quizz.
9. **Add question to quiz**: Add question to quiz if question doesn't exist in that quizz.

## Design Patterns
The project implements the following design patterns:
1. **Command Query Responsibility Segregation (CQRS)**: CQRS with MediatR allow separation of read and write operations, improving performance and maintainability.
2. **Repository Pattern**: Provides a more readable way to handle database operations and gives better control over the business logic.

## Extensibility with Managed Extensibility Framework (MEF)
The QuizApi supports pluggable exporters to enable the flexible exporting of quiz data in various formats. The MEF allows the API to dynamically load new exporters at runtime without needing to recompile the project. 

### Creating a New Exporter

To create a new data exporter, follow these steps:

1. Create a new class library project for your exporter.
2. In your new project, create a class that implements the `IExporter` interface.

   For instance, to create a CSV exporter, your class might look like this:
   
   ```csharp
   [Export(typeof(IExporter))]
   public class CSVExporter : IExporter
   {
       public string Format => "csv";
       public string ContentType => "text/csv";
       
       public byte[] Export(QuizWithQuestionTextDTO quiz)
       {
           // Implement the export functionality here.
       }
   }
3. Add a post-build event in exporter project to copy the output DLL to the exporters directory of the QuizApi project.
   
   ```text
   if not exist "$(SolutionDir)QuizApi\bin\$(Configuration)\$(TargetFramework)\exporters" mkdir "$(SolutionDir)QuizApi\bin\$(Configuration)\$(TargetFramework)\exporters"
   xcopy /y "$(TargetDir)*.dll" "$(SolutionDir)QuizApi\bin\$(Configuration)\$(TargetFramework)\exporters\"

4. Open exporter project csproj file and inside `PropertyGroup` add `<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>`
   
   Example:
      ```csharp
     <PropertyGroup>
        <TargetFramework>net6.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
	    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
    </PropertyGroup>
5. Build your exporter project.

Once these steps are complete, QuizApi can load and use your exporter at runtime without needing to recompile. To verify the availability of your exporter, call the `api/quiz/exporter` endpoint of the QuizApi.

Currently QuizApi only have csv exporter but for easier testing i made PDFExporter project and if you follow steps above you can test how adding new exporter work.
## API Documentation
The API uses Swagger for documentation. Swagger provides an interactive interface for users to try out the API calls, inspect responses, and understand the capabilities of the API. You can access the Swagger UI by navigating to the `/swagger` endpoint of the QuizApi after running it.

## Setup and Running the Project
To run the project:

1. Install [PostgreSQL](https://www.postgresql.org/download/) and [pgAdmin](https://www.pgadmin.org/download/).
2. Add your connection string to the `appsettings.json` file in the QuizApi project.
3. In the package manager console, run `Update-Database` to create the necessary database tables using Entity Framework migrations.
4. Build the solution before running the QuizApi project. This will ensure any exporter DLLs are copied to the correct location.
