	//start op the GameManager
	public void StartState(string player1Name, string player2Name)
	{
		AddPlayer(player1Name, "Human");
		AddPlayer(player2Name, "Human");
	}

if(GUI.Button(new Rect(0 + Screen.width/2 - 65, 0 + Screen.height/2, 130, 50), "Start Game"))
{
	StartGame();
	Application.LoadLevel ("sceneProto"); 
}

private void StartGame()
{
	DontDestroyOnLoad(GameManager_script.ManagerInstance);
	GameManager_script.ManagerInstance.StartState(player1Name, player2Name);
}

private static GameManager_script managerInstance;
//get Singleton Instance of GameManager so that it can persist all data through all scenes
public static GameManager_script ManagerInstance
{
	get
	{
		if(managerInstance == null)
		{
			managerInstance = new GameObject("GameManager_script").AddComponent<GameManager_script>();
		}
		return managerInstance;
	}
}

void Awake()
{	
	Game_script.GameInstance.StartGameState();
	this.PlayersInGame = new List<Player_script>();
	this.DicesInGame = new List<Dice_script>();
}