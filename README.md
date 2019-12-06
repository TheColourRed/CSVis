# CSVis
  A Unity based CSV data visualizer application for creating and viewing data plots in mixed reality through the Microsoft HoloLens. 

  The application uses the open source [Data Visualization Plotter](https://github.com/jman19/DataVisualizationPlotter) toolkit and the 
  [MixedRealityToolkit-Unity](https://github.com/Microsoft/MixedRealityToolkit-Unity/releases) by Microsoft to plot 3D data in Mixed Reality space to offer a different perspective in viewing 3D data.

## What can it do?
  1. CSVis can plot static 2D / 3D data plots from predefined examples
  1. Manipulate the plots with hand gestures for placement of the plots in your surroundings

## Current state of the project
  The [Data Visualization Plotter](https://github.com/jman19/DataVisualizationPlotter) toolkit and this application
is still in its development stages but is trajected to incorporate new toolkit features as they are released.
Some features in development are: 
* Selection and configuration of csv data file in the HoloLens file system to be plotted in 3D (the file system includes OneDrive and DropBox)
* Plot animated time series plots of singular and multiple data points
* Tool tip information for data points being viewed by the user to show exact coordinates
* Add geological data mapping to connect GPS coordinates
