using MapReduce;

// mapping
Mapper mapper = new Mapper();
mapper.Map("texts");
// reducing
Reducer reducer = new Reducer();
reducer.Reduce("maps");
// outputing result to console
using (StreamReader reader = new StreamReader("output.tsv"))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}