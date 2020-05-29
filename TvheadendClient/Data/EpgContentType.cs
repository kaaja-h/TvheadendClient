using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TvheadendClient.Data
{
    public class EpgContentType
    {

        public static IReadOnlyDictionary<long, EpgContentType> DefaultContentTypes =>
            _contentTypes.Value[defaultCuntureCultureInfo];
        public static IReadOnlyDictionary<CultureInfo, IReadOnlyDictionary<long, EpgContentType>> ContentTypes => _contentTypes.Value;


        private static readonly Lazy<IReadOnlyDictionary<CultureInfo, IReadOnlyDictionary<long, EpgContentType>>> _contentTypes
            = new Lazy<IReadOnlyDictionary<CultureInfo, IReadOnlyDictionary<long, EpgContentType>>>(Load);

        private static readonly CultureInfo defaultCuntureCultureInfo = CultureInfo.GetCultureInfo("EN_us");


        private static IEnumerable<CultureInfo> ParseHeader(string header)
        {
            var headerArray = header.Split(';');
            if (headerArray.Length < 4 || headerArray.Length%2!=0)
                throw new Exception("Invalid data");
            if (headerArray[0]!= "LEVEL_1" || headerArray[1] != "LEVEL_2")
                throw new Exception("Invalid data");
            for (int i = 2; i < headerArray.Length; i += 2)
            {
                if (!headerArray[i].StartsWith("LEVEL_1") || !headerArray[i+1].StartsWith("LEVEL_2")
                    || headerArray[i].Substring(7)!= headerArray[i+1].Substring(7)
                )
                    throw new Exception("Invalid data");
                var lang = headerArray[i].Substring(8);
                yield return CultureInfo.GetCultureInfo(lang);
            }

        }

        private static IReadOnlyDictionary<CultureInfo, IReadOnlyDictionary<long, EpgContentType>> Load()
        {
            var output = new Dictionary<CultureInfo, Dictionary<long, EpgContentType>>();
            using (var data = Assembly.GetAssembly(typeof(EpgContentType))
                .GetManifestResourceStream("TvheadendClient.Resources.epg.csv"))
            {
                using (StreamReader sr = new StreamReader(data))
                {
                    var header = sr.ReadLine();
                    var languages = ParseHeader(header).ToArray();
                    foreach (var lang in languages)
                    {
                        output[lang] = new Dictionary<long, EpgContentType>();
                    }

                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split(';');
                        if (line.Length != languages.Length * 2 + 2) 
                            throw new Exception("invalid data");
                        var convertor = new ByteConverter();
                        var l1 = (byte) convertor.ConvertFromString(line[0]);
                        var l2 = (byte)convertor.ConvertFromString(line[1]);
                        for (int i = 0; i < languages.Length; i++)
                        {
                            var l1Desc = line[(i + 1) * 2];
                            var l2Desc = line[(i + 1) * 2 + 1];
                            var a = new EpgContentType(l1, l2, l1Desc, l2Desc);
                            output[languages[i]][a.Value] = a;
                        }
                    }
                } 
            }
            return output.ToDictionary(d=>d.Key, d=>(IReadOnlyDictionary<long, EpgContentType>)d.Value);
        }

        public byte Level1 { get; private set; }
        public byte Level2 { get; private set; }
        public string Level1Description { get; private set; }
        public string Level2Description { get; private set; }

        public long Value { get; private set; }


        private EpgContentType(byte l1, byte l2, string l1Desc, string l2Desc)
        {
            Level1 = l1;
            Level2 = l2;
            Level1Description = l1Desc?.Trim();
            Level2Description = l2Desc?.Trim();
            Value = l1 * 16 + l2;
        }

    }
}
