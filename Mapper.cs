namespace MapReduce;
public class Mapper
{
    public void Map(string inputDirectory)
    {
        string[] files = Directory.GetFiles(inputDirectory);

        foreach (string file in files)
        {
            Dictionary<string, int> wordCounts = new();

            using StreamReader reader = new StreamReader(file);
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

            string outputFileName = Path.GetFileNameWithoutExtension(file) + "_map.tsv";
            string outputFilePath = Path.Combine("maps", outputFileName);
            using StreamWriter writer = new StreamWriter(outputFilePath);
            foreach (KeyValuePair<string, int> kvp in wordCounts)
            {
                writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
            }
        }
    }
}
