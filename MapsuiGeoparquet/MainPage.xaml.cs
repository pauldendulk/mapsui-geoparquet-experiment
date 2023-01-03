using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Styles;
using MapsuiGeoparquet.Providers;

namespace MapsuiGeoparquet;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var mapControl = new Mapsui.UI.Maui.MapControl();
        mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        mapControl.Map?.Layers.Add(CreateGeoParquetLayer());

        Content = mapControl;
    }

    private ILayer CreateGeoParquetLayer()
    {
        var geoParquetProvider = new GeoParquetProvider();
        geoParquetProvider.LoadData();

        return new Layer
        {
            Style = new VectorStyle { Fill = new Mapsui.Styles.Brush(Mapsui.Styles.Color.FromArgb(64, 255, 255, 255)), Outline = new Pen(Mapsui.Styles.Color.Black, 3) },
            DataSource = new ProjectingProvider(geoParquetProvider) { CRS = "EPSG:3857" }
        };
    }
}
