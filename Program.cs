using MapReduce;

Mapper mapper = new Mapper();
string inputFilePath = Console.ReadLine()!;
mapper.Map(inputFilePath);
