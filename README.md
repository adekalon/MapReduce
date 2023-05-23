# WordCount MapReduce Console App

This is a .NET console application that implements a basic WordCount MapReduce algorithm. The application takes a directory "texts" containing tab separated text files as input, performs the map and reduce operations, and outputs the word counts to the console.

### Compilation and Execution
1. Ensure you have the .NET SDK installed on your machine. You can download it from the official [.NET website](https://dotnet.microsoft.com/en-us/download).
2. Run the following command to clone the repository: `git clone https://github.com/adekalon/MapReduce.git`.
3. Navigate to the project directory: `cd MapReduce`.
4. Run the following command to execute the program: `dotnet run`.

### Input/Output
- Initially "texts" contains some test files for testing, but you can add (or replace them with) your texts
- Results of mapping will be stored in "maps" folder (separate map for each input file).
- Results of reducing will be stored in "output" folder. This folder will contain 2 files: `output.tsv` (contains all kvps with no orderin), `frequency_output.tsv` (keys are sorted by frequency)
