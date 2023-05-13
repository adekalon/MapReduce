using MapReduce;

Mapper mapper = new Mapper();
string inputFilePath = Console.ReadLine()!;
mapper.Map(inputFilePath);
Console.WriteLine("Mapping completed.");
