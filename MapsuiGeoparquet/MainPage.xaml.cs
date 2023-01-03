using Mapsui.Layers;
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
            Style = new VectorStyle(),
            DataSource = geoParquetProvider
        };
    }
}
