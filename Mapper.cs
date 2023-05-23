namespace MapReduce;
public class Mapper
{
    private readonly char[] punctuationMarks = { ',', '.', '!', '?', '(', ')', ':', ';', '"' };

    public void Map(string inputDirectory)
    {
        // delete maps directory to make sure that only selected files will be mapped
        // definetely for future versions)
        if (Directory.Exists("maps"))
            {
                Directory.Delete("maps", true);
            }

        Directory.CreateDirectory("maps");

        string[] files = Directory.GetFiles(inputDirectory);

        foreach (string file in files)
        {
            Dictionary<string, int> wordCounts = new();

            using StreamReader reader = new StreamReader(file);
            string? line;
            while ((line = reader.ReadLine()) is not null)
            {
                string[] words = line.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(word => word.Trim(punctuationMarks))
                                 .ToArray();
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
