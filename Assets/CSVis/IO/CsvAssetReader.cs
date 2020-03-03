using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvAssetReader
{

    private TextAsset csvFile;

    public CsvAssetReader(TextAsset csvFile)
    {
        this.csvFile = csvFile;
    }

    public Dictionary<string, List<float>> GetColumnsByHeader(params string[] names)
    {
        Dictionary<string, List<float>> valuesByName = new Dictionary<string, List<float>>();

        using (TextReader reader = new StringReader(this.csvFile.text))
        using (var csv = new CsvReader(reader))
        {
            csv.Read();
            csv.ReadHeader();

            Array.ForEach(names, name => valuesByName.Add(name, new List<float>()));

            while (csv.Read())
            {
                Array.ForEach(names, name => valuesByName[name].Add(csv.GetField<float>(name)));
            }
        }

        return valuesByName;
    }
}
