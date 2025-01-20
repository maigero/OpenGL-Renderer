using System.IO;

namespace ObjLoader.Loader.Loaders
{
    public abstract class LoaderBase
    {
        private StreamReader _lineStreamReader;
        public string basePath;
        protected void StartLoad(Stream lineStream)
        {
            _lineStreamReader = new StreamReader(lineStream);
            this.basePath = Path.GetDirectoryName((lineStream as FileStream)?.Name);

            while (!_lineStreamReader.EndOfStream)
            {
                ParseLine();
            }
        }

        private void ParseLine()
        {
            var currentLine = _lineStreamReader.ReadLine();

            if (string.IsNullOrWhiteSpace(currentLine) || currentLine[0] == '#')
            {
                return;
            }

            var fields = currentLine.Trim().Split(null, 2);
            var keyword = fields[0].Trim();
            var data = fields[1].Trim();

            var matPath = Path.GetDirectoryName(data);
            if (keyword == "mtllib")
            {
                ParseLine(keyword, Path.Combine(this.basePath, data));
            }
            else
            {
                ParseLine(keyword, data);
            }
        }

        protected abstract void ParseLine(string keyword, string data);
    }
}