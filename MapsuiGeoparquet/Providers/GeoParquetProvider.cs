using Mapsui;
using Mapsui.Layers;
using Mapsui.Nts;
using Mapsui.Providers;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using ParquetSharp;

namespace MapsuiGeoparquet.Providers
{
    internal class GeoParquetProvider : IProvider
    {
        public string? CRS { get; set; } = "EPSG:4326";
        private List<IFeature> features = new List<IFeature>();

        public MRect? GetExtent()
        {
            return features.First().Extent;
        }

        public Task<IEnumerable<IFeature>> GetFeaturesAsync(FetchInfo fetchInfo)
        {
            return Task.FromResult((IEnumerable<IFeature>)features);
        }

        public void LoadData()
        {
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/gemeenten2016_1.0.parquet");
            var file1 = new ParquetFileReader(file);
            var rowGroupReader = file1.RowGroup(0);
            var geometryWkb = rowGroupReader.Column(17).LogicalReader<byte[]>().First();
            var wkbReader = new WKBReader();
            var multiPolygon = (MultiPolygon)wkbReader.Read(geometryWkb);
            features.Add(new GeometryFeature(multiPolygon));
        }
    }
}
