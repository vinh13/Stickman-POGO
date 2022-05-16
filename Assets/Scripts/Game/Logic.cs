using UnityEngine;

public class Logic
{
    public static bool IsPause = false;
    public static bool IsEnd = false;
    public static int IdLevel = 1;
    public static int NumberLevel = 9;
    public static string NameMode = "";
    public static void PAUSE()
    {
        if (IsPause)
            return;
        IsPause = true;
        Time.timeScale = 0;
    }

    public static void UNPAUSE()
    {
        if (!IsPause)
            return;
        IsPause = false;
        Time.timeScale = 1;
    }
}
