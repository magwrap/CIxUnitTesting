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

# Set Up Continuous Integration on GitHub

1. On your GitHub repository, click on Actions.
2. Search for or select .NET, but not .NET Desktop
3. Click on Configure.
4. This will create a YAML file something like the following:

### This workflow will build a .NET project
For more information see: https://docs.github.com/en/actions/automating-
builds-and-tests/building-and-testing-net
name: .NET
on:
push:
branches: [ "main" ]
pull_request:
branches: [ "main" ]
jobs:
build:
runs-on: ubuntu-latest
steps:
- uses: actions/checkout@v3
- name: Setup .NET
uses: actions/setup-dotnet@v3
with:
dotnet-version: 6.0.x
- name: Restore dependencies
run: dotnet restore
- name: Build
run: dotnet build --no-restore
- name: Test
run: dotnet test --no-build --verbosity normal
We need to change some things given our project setup, which we can do directly
from the GitHub file editor:
https://sdu.itslearning.com/plans/courses/31162/plan/257640/resource/1423477?BackDestination=0&planner2-sb-collapsed=false
 4/6
26/02/2024, 23:50
 Continuous Integration (CI) in GitHub for xUnit testing
5. Ensure your dotnet-version is set correctly in the YAML file; you can do this from
the VS Code Terminal by dotnet --version. Hopefully, you have version 8.0.x at this
point, as you will need it later in the course.
6. We need to modify the -name parts, which are currently as follows:
- name: Restore dependencies
run: dotnet restore
- name: Build
run: dotnet build --no-restore
- name: Test
run: dotnet test --no-build --verbosity normal
Currently, this works basically expecting the project to work on one root directory,
but that's not we have. We have two directories (e.g., Project and Project.Tests). So,
we need to update this part to work properly with that setup, replacing the
example folders with the name of your actual project and test directories. Also, the
--no-build can run into issues, so we'll simplify the dotnet test command.
- name: Restore dependencies (Project)
run: dotnet restore
working-directory: Project
- name: Build (Project)
run: dotnet build --no-restore
working-directory: Project
- name: Restore dependencies (Project.Tests)
run: dotnet restore
working-directory: Project.Tests
- name: Test (Project.Tests)
run: dotnet test
working-directory: Project.Tests
If you want to specify a specific build configuration (Debug or Run), you can change
the
dotnet build --no-restore to, for instance, dotnet build --no-restore --configuration
Release
7. Commit the file on the main branch from GitHub after modifying it.
8. Back in VS Code, run git pull in the Terminal to get the latest changes from main.
9. After this, the Actions can be viewed on GitHub or through the GitHub Actions
extension in VS Code. Every time you make a new test and push it to the
repository, the Test will automatically run now.
This concludes the steps for creating a new project set up for xUnit testing, that then later
uses GitHub for Continuous Integration and version control. The steps are slightly different if
you start by creating the repository first, as outlined in Method 1.

