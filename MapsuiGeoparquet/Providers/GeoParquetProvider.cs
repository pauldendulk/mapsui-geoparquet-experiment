using Mapsui;
using Mapsui.Layers;
using Mapsui.Providers;

namespace MapsuiGeoparquet.Providers
{
    internal class GeoParquetProvider : IProvider
    {
        public string CRS { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MRect? GetExtent()
        {
            return null;
        }

        public Task<IEnumerable<IFeature>> GetFeaturesAsync(FetchInfo fetchInfo)
        {
            return Task.FromResult(Enumerable.Empty<IFeature>());
        }

        public void LoadData()
        { 
        
        }
    }
}
