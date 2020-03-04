using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using UnityEngine;

namespace CSVis.IO
{
    /// <summary>
    /// A utility class to read a csv file text asset 
    /// </summary>
    public class CsvAssetReader
    {

        private readonly TextAsset csvFile;

        public CsvAssetReader(TextAsset csvFile)
        {
            this.csvFile = csvFile;
        }

        /// <summary>
        /// Returns a dictionary of column value lists by their header names
        /// </summary>
        public Dictionary<string, List<float>> GetColumnsByHeader(params string[] names)
        {
            var valuesByName = new Dictionary<string, List<float>>();

            using (TextReader reader = new StringReader(csvFile.text))
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
        
        
        /// <summary>
        /// Returns a dictionary of column value lists by their indices 
        /// </summary>
        public Dictionary<int, List<float>> GetColumnsByIndex(params int[] indices)
        {
            var valuesByName = new Dictionary<int, List<float>>();

            using (TextReader reader = new StringReader(csvFile.text))
            using (var csv = new CsvReader(reader))
            {
                Array.ForEach(indices, i => valuesByName.Add(i, new List<float>()));

                while (csv.Read())
                {
                    Array.ForEach(indices, i => valuesByName[i].Add(csv.GetField<float>(i)));
                }
            }

            return valuesByName;
        }
    }
}
