using System;

namespace CEUtilities
{
    public class Sound
    {
        private static string soundLocation = @"sounds\";

        public static void PlaySound(string fileName)
        {
            CoreDll.PlaySound(Sound.soundLocation + fileName, IntPtr.Zero, (int)(CoreDll.SND.SYNC | CoreDll.SND.FILENAME));
        }
    }
}