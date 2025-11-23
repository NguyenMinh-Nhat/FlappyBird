using SplashKitSDK;
namespace CustomProgram
{
    public class InputManager
    {
        private GameManager gameManager;
        void Update()
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                // Notify Gamanager to process state
                gameManager.ProcessInput();
            }
        }
    }
}