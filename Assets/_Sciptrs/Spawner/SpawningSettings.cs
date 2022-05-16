namespace MyGame
{
    [System.Serializable]
    public struct SpawningSettings
    {
        public int StartSpawnCount;
        public int AmountPerSpawn;
        public int Limit;
        public float SpawnInterval_min;
        public float SpawnInterval_max;
        
    }
}