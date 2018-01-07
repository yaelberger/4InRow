namespace FourInRowWindowsApp
{
    public class Program
    {
        public static void Main()
        {
            FormGameSettings formGameSetting = new FormGameSettings();
            formGameSetting.ShowDialog();
            FormGame formGame = new FormGame();
            formGame.RunGame();
        }
    }
}
