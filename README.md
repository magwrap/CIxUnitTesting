# Set Up

1. Create a new root folder.
2. In that root folder, make two subfolders, one for the Project files and one for the
Testing files, something like NameOfProject and NameOfProject.Tests (I'll use
Project and Project.Tests in this example to simplify things).
3. Go to the Project folder: cd Project
4. Create the console project: dotnet new console
5. Go to the Project.Tests folder.
cd ..
cd Project.Tests
6. Create the xUnit project: dotnet new xunit
7. Add a reference to the Project in the xUnit Test Project:
dotnet add reference ../Project/Project.csproj
8. Write a basic Test.
9. Test it while in the Project.Tests folder: dotnet test


