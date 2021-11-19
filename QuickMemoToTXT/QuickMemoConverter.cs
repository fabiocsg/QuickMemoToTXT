using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Newtonsoft.Json;
using QuickMemoToTXT.Models;

namespace QuickMemoToTXT
{
    internal class QuickMemoConverter
    {
        private const string LqxExt = ".lqm";
        private const string JlqxExt = ".jlqm";
        private const string TxtExt = ".txt";

        private readonly string _filesDir;
        private readonly string _outputDir;
        private readonly Action<string> _logAction;

        public QuickMemoConverter(string filesDir, string outputDir, Action<string> logAction = null)
        {
            _filesDir = filesDir;
            _outputDir = outputDir;
            _logAction = logAction;
        }

        public void Run()
        {
            var lqmFiles = Directory.GetFiles(_filesDir)
                .Where(f => f.EndsWith(LqxExt, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            if (!lqmFiles.Any())
            {
                _logAction?.Invoke($"No ${LqxExt} files found in the directory");
                return;
            }

            foreach (var fileName in lqmFiles)
                ConvertFile(fileName);
        }

        private void ConvertFile(string filePath)
        {
            var outPath = Path.Combine(_outputDir, $"{Path.GetFileNameWithoutExtension(filePath)}{TxtExt}");

            _logAction?.Invoke($"Processing file: '{Path.GetFileName(filePath)}'");

            using var archive = ZipFile.OpenRead(filePath);
            foreach (var entry in archive.Entries)
            {
                if (!entry.FullName.EndsWith(JlqxExt, StringComparison.InvariantCultureIgnoreCase))
                    continue;

                using var stream = entry.Open();
                using var reader = new StreamReader(stream);
                var jsonString = reader.ReadToEnd();

                var lqm = JsonConvert.DeserializeObject<Lqm>(jsonString);
                var descs = lqm.MemoObjectList.Select(mo => mo.DescRaw);
                var text = string.Join(Environment.NewLine, descs);
                File.WriteAllText(outPath, text);
            }
        }
    }

    
}
