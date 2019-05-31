# invitation

Based the users location, the software allows to select the nearest users within the range.

## Features

* select the closest users based on their location;
* range and center location now hard coded and they are 100 as a distance in km, 53.339428 is latitude, -6.257664 is longitude;
* input file url should be provided by argument of command line;
* input file is set of serialized json-objects separated by new-line marker;
* **output is output.json** in the root: it is an json-array of user objects contain only user_id and name;

## Configuration and Usage

Solution wrote on .NET Core 2.2. To run and debug it locally you need:

* download and install .NET Core SDK 2.2: <https://dotnet.microsoft.com/download>, it is cross-platform;
* if you want use console, you should:
  * to run: run console command `dotnet run -p ConsoleRunner/ConsoleRunner.csproj` and an argument input file url, for example the test one: <https://raw.githubusercontent.com/FiodorTretyakov/invitation/master/Test/customers.txt>;
  * to test: run console command `dotnet test /p:CollectCoverage=true`, it will run tests and show the code coverage;
* if you want sue vscode, you should:
  * download and install it from: <https://code.visualstudio.com/Download>;
  * to run: Go to Launch -> Debug Run configuration -> specify the input url (there is test default provided);
  * to debug: Go to Tasks -> Run test watch;
* if you just want to run it without any installations, just go to `builds/{CurrentBuild}/{YourOS}`, I provided win-x64, linux-x64 and osx-x64 packages included all dependencies;

## Technical and Design decisions

I selected .net core because of it is cross-platform, great performing, open source and convenient to use framework.
The code consist of 3 projects:

* Customers: library solves the main problem;
* ConsoleRunner: console application that just uses library;
* Test;

### Customers

* Entity: Location and its extended: Customer (because of Customer we use only as "located customer");
* Locator: all computations around the geo-location;
* Processor: abstract class that contain all methods for the software, but SaveData and GetData without implementation to define them in extended, because of I don't want limit ways how to do it in core level;
* FileProcessor: it is Processor extended, but allow to download input by url and save it to local file;
