namespace StarboundTLOPatcher
{
    public static class TLOPatcher
    {
        public static async Task Run(string modPath, string outputPath)
        {
            try
            {
                string patchData = await File.ReadAllTextAsync(Path.Combine(Environment.CurrentDirectory, "patch.json"));
                string[] objects = Directory.GetFiles(modPath, "*.object", SearchOption.AllDirectories);
                int count = 0;

                foreach (string obj in objects)
                {
                    if (await RequiresPatchAsync(obj))
                    {
                        string objPath = obj[obj.IndexOf("object")..obj.LastIndexOf('\\')];

                        Directory.CreateDirectory(Path.Combine(outputPath, objPath));
                        await File.WriteAllTextAsync(Path.Combine(outputPath, objPath, Path.GetFileName(obj) + ".patch"), patchData);

                        count++;
                    }
                }

                Console.WriteLine($"Successfully created {count} patch files.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static async Task<bool> RequiresPatchAsync(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    // checks work only if key and value are on the same lines
                    if (line.Contains("\"lightColor\"") || line.Contains("\"activeLightColor\""))
                    {
                        if (line.Replace(" ", "").Contains("[0,0,0]")) // check if light color is not 0, 0, 0
                        {
                            return false;
                        }

                        using (StreamReader pointLightReader = new StreamReader(path)) // check if point light is already present
                        {
                            string? pointLightCheck;

                            while ((pointLightCheck = await pointLightReader.ReadLineAsync()) != null)
                            {
                                if (pointLightCheck.Contains("pointLight") && pointLightCheck.Contains("true"))
                                {
                                    return false;
                                }
                            }
                        }

                        return true;
                    }
                }

                return false;
            }
        }
    }
}
