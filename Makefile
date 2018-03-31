PROJECT_FILE = ./ThirtySecondsOfCSharp/ThirtySecondsOfCSharp.csproj
TEST_PROJECT_FILE = ./ThirtySecondsOfCSharp.Tests/ThirtySecondsOfCSharp.Tests.csproj

build:
	dotnet build $(PROJECT_FILE)
	dotnet build $(TEST_PROJECT_FILE)

test:
	dotnet test $(TEST_PROJECT_FILE)

clean:
	dotnet clean $(PROJECT_FILE)
	dotnet clean $(TEST_PROJECT_FILE)