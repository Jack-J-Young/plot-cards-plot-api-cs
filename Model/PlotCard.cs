namespace Model
{
    public class PlotCard
    {
        public float[,] HeightMap { get; }

        public uint Width => (uint) HeightMap.GetLength(0);
        public uint Height => (uint) HeightMap.GetLength(1);

        public PlotCard(uint width, uint height)
        {
            HeightMap = new float[width, height];
        }
    }
}
