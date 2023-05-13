namespace MapReduce;

public class Mapper
{
    public void Map(string inputFilePath)
    {
        Dictionary<string, int> wordCounts = new();

        using StreamReader reader = new(inputFilePath);
        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            string[] words = line.Split('\t');
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
            }
        }

        string outputFilePath = Path.ChangeExtension(inputFilePath, "_map.tsv");
        using StreamWriter writer = new(outputFilePath);
        foreach (KeyValuePair<string, int> kvp in wordCounts)
        {
            writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
        }
    }
}
