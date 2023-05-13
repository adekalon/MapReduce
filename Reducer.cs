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

            string outputFilePath = "output.tsv";
            using StreamWriter writer = new StreamWriter(outputFilePath);
            foreach (KeyValuePair<string, int> kvp in reducedWordCounts)
            {
                writer.WriteLine($"{kvp.Key}\t{kvp.Value}");
            }
        }
    }
}