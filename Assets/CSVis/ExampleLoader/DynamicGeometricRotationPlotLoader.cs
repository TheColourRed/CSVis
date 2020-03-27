using System;
using System.Collections.Generic;
using System.Linq;
using CSVis.ExampleLoader.Helper;
using CSVis.IO;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class DynamicGeometricRotationExample : PlotLoader
    {
        private const string Title = "Dodecahedron Rotations";
    
        private const string XLabel = "X";
   
        private const string YLabel = "Y";
        
        private const string ZLabel = "Z";
   
        private const int XOffset = 0;

        private const int YOffset = 1;
    
        private const int ZOffset = 2;

        private const int NPoints = 20;
    
        private const string CsvResourcePath = "Data/dodecahedron_rotation";
        
        public override void LoadPlot()
        {
            var plot = Instantiate(GetSineWavePlotter());
            SetSpawn(plot.PointHolder);
    
        }

        public DynamicPlotter GetSineWavePlotter()
        {
            var columnsByIndex = CsvUtils.GetColumnsByIndex<float>(CsvResourcePath, Enumerable.Range(0, NPoints * 3).ToArray());
            var capacity = columnsByIndex[0].Count;
            var pointColumns = new List<DynamicPlotHelper.DynamicPlotData.PointColumns>();

            for (int i = 0; i < NPoints; i++)
            {
                int offset = i * 3; 
                pointColumns.Add(
                    new DynamicPlotHelper.DynamicPlotData.PointColumns(
                        columnsByIndex[offset + XOffset],
                        columnsByIndex[offset + YOffset],
                        columnsByIndex[offset + ZOffset]
                    ));
            }
        
            var times = Enumerable.Range(0, capacity).Select(i => i.ToString()).ToList();

            var data = new DynamicPlotHelper.DynamicPlotData(
                Title,
                pointColumns,
                times,
                XLabel,
                YLabel,
                ZLabel
            );
            
            return DynamicPlotHelper.GetDynamicPlotter(data);
        }
    }
}