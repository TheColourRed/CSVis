﻿using System.Collections.Generic;
using System.Data;
using CSVis.ExampleLoader.Helper;
using CSVis.IO;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    
    public class DynamicDronePlotLoader : PlotLoader
    {
        private const string Title = "Drone Flight Path";
           
        private const string XHeader = "latitude";

        private const string YHeader = "altitude (m)";
            
        private const string ZHeader = "longitude";
        
        private const string TimeHeader = "time(local time)";

        private const string CsvResourcePath = "Data/FlightData2";

        public override void LoadPlot()
        {
            var dynamicPlotter = GetDynamicDronePlotter();
            var staticPlotter = GetStaticDronePlotter();

            dynamicPlotter.PlotScale = 1;
            staticPlotter.plotScale = 1;

            var pointHolder = dynamicPlotter.PointHolder;
            staticPlotter.PointHolder = pointHolder;
            
            var staticExample = Instantiate(staticPlotter);
            var dynamicExample = Instantiate(dynamicPlotter);

            SetSpawn(dynamicExample.PointHolder);
            SetSpawn(staticExample.PointHolder);
        }

        public DynamicPlotter GetDynamicDronePlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByHeader<float>(CsvResourcePath, XHeader, YHeader, ZHeader);
            var times = CsvUtils.GetColumnsByHeader<string>(CsvResourcePath, TimeHeader)[TimeHeader];

            var pointColumns =
                new List<DynamicPlotHelper.DynamicPlotData.PointColumns>()
                {
                    new DynamicPlotHelper.DynamicPlotData.PointColumns(
                        columnsByName[XHeader],
                        columnsByName[YHeader],
                        columnsByName[ZHeader]
                    )
                };

            var data = new DynamicPlotHelper.DynamicPlotData(
                Title,
                pointColumns,
                times,
                XHeader,
                YHeader,
                ZHeader
            );

            return DynamicPlotHelper.GetDynamicPlotter(data);
        }
        
        public DataPlotter GetStaticDronePlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByHeader<float>(CsvResourcePath, XHeader, YHeader, ZHeader);

            var data = new StaticPlotHelper.StaticPlotData(
                "",
                columnsByName[XHeader],
                columnsByName[YHeader],
                columnsByName[ZHeader],
                "",
                "",
                ""
            );

            return StaticPlotHelper.GetStaticPlotter(data);
        }
    }
}