# Project
This repository contains a sample project of a .NET 8 WebApi using CleanArchitecture. Currently, a lot of files are stubbed or not implemented, but the project serves as a starting point for a more complex project.

The purpose of this project is to showcase my skills in software development, architecture, and design patterns. The project is not a complete solution.

## Project Structure
The project is structured in the following way:
- `src/` contains the source code of the project
- `tests/` contains the tests of the project

### Clean Architecture
The project is structured following the Clean Architecture principles. The project is divided into the following layers:
- `Core`: Contains the heart of the application.Ddomain entities, abstraction interfaces and business logic can be found here.
- `Infrastructure`: Contains the implementation of the interfaces defined in the `Domain` layer. This layer is responsible for implementations of abstractions defined in the Core layer and is the layer responsible for communication with external services, such as databases, file systems, etc.
- `WebApi`: Contains the WebApi project, using a REST .NET 8 API. This layer is responsible for the communication with the outside world, and is the entry point of the application.

One will notice that there exists no `Application` layer. This is inspired upon Microsoft's article about an inside look into their .NET Clean Architecture, [an article that can be found here.](https://devblogs.microsoft.com/ise/next-level-clean-architecture-boilerplate/)

## Running the project
To run the project, follow these steps:

1. Clone the repository
2. Open the solution in an IDE of your choice
3. Build the solution and restore the NuGet packages
4. Start the API project
5. The API should now be running on `https://localhost:7204`

### Docker

Alternatively, one can build a docker container.

1. Clone the repository
2. Open a terminal and navigate to the root of the repository
3. Run the following command: `docker build -t clean-architecture -f Dockerfile .`
4. Run the following command: `docker run -p 5027:5027 clean-architecture`
5. The API should now be running on `http://localhost:5027`