namespace MapReduce;

public class Reducer
{
    public void Reduce(string inputDirectory)
    {
        string[] files = Directory.GetFiles(inputDirectory);
        Dictionary<string, int> reducedWordCounts = new();

        foreach (string file in files) 
        {
            using StreamReader reader = new StreamReader(file);
            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                string[] kvp = line.Split('\t');
                string key = kvp[0];
                int value = int.Parse(kvp[1]);
                if (!string.IsNullOrEmpty(key))
                {
                    if (reducedWordCounts.ContainsKey(key))
                    {
                        reducedWordCounts[key] += value;
                    }
                    else
                    {
                        reducedWordCounts[key] = value;
                    }
                }
            }
        }

        string outputDirectoryPath = "output";

        if (Directory.Exists(outputDirectoryPath))
        {
            Directory.Delete(outputDirectoryPath, true);
        }

        Directory.CreateDirectory(outputDirectoryPath);
        
        string outputFilePath = Path.Combine(outputDirectoryPath, "output.tsv");
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (KeyValuePair<string, int> kvp in reducedWordCounts)
            {
                writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
            }
        }
        
        string frequencyOutputFilePath = Path.Combine(outputDirectoryPath, "frequency_output.tsv");
        using (StreamWriter frequencyWriter = new StreamWriter(frequencyOutputFilePath))
        {
            List<KeyValuePair<string, int>> sortedKvps = reducedWordCounts.OrderByDescending(x => x.Value).ToList();
        
            foreach (KeyValuePair<string, int> kvp in sortedKvps)
            {
                frequencyWriter.WriteLine($"{kvp.Key}\t{kvp.Value}");
            }
        }

    }
}