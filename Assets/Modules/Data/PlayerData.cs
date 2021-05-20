using System;

namespace Modules.Data
{
    [Serializable]
    public class PlayerData
    {
        public int LevelIdx;
        public bool SoundEnabled;
        public bool MusicEnabled;

        public PlayerData()
        {
            SoundEnabled = true;
            MusicEnabled = true;
        }
    }
}