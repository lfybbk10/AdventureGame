
public class Game
{
    public GameStateMachine StateMachine;
    public Game(LoadingCurtain loadingCurtain,ICoroutineRunner coroutineRunner)
    {
        StateMachine = new GameStateMachine(loadingCurtain,new SceneLoader(coroutineRunner));
    }
}
