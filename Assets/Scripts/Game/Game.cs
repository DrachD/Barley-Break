using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private Transform pointsParent;

    [SerializeField] private PanelController panelController;

    [SerializeField] private GameObject prefabNode;
    [SerializeField] private Sprite[] sprites;
    private SFXPlayer sfxPlayer;
    private BarleyBreakData barleyBreakData;
    public int fieldSizeId;
    private int[,] idBlocks;
    private Node[] nodes;
    private GameObject[,] gameObjects;
    private GameObject[] gamePrefabs;
    private GameObject obj;
    public Texture2D texture;
    public int CameraSize => barleyBreakData.CameraSize;

    // Field size and start filling data
    private int x;
    private int y;
    private int firstCoordX;
    private int firstCoordY;
    private static System.Random rnd = new System.Random();

    #region Main Functions
    private void Awake()
    {
        barleyBreakData = SelectedField.BarleyBreakData;
        sfxPlayer = FindObjectOfType<SFXPlayer>();
        SetFieldData();
        fieldSizeId = 0;
        gameReset = true;
        firstGame = true;
        if (nodes == null)
        {
            nodes = new Node[barleyBreakData.X * barleyBreakData.Y];
            gamePrefabs = new GameObject[barleyBreakData.X * barleyBreakData.Y];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node();
                gamePrefabs[i] = Instantiate(prefabNode);
            }
        }
    }

    private void Start()
    {
        texture = Resources.Load<Texture2D>("Barley");
        
        sprites = Resources.LoadAll<Sprite>(texture.name);

        score = FindObjectOfType<Score>();

        Initialization();
        DataFilling();
    }

    public bool gameReset;
    private bool firstGame;
    private void Update()
    {
        if (!gameReset) { return; }

        countScore = 0;
        score.SetPoint(countScore);
        gameReset = false;

        Shuffle();
        CreateBlocksSequence();
    }
    #endregion

    #region Moving Blocks
    private int idEmptyBlockX;
    private int idEmptyBlockY;
    private int countScore = 0;
    public void MoveNode(int idX, int idY)
    {
        int dx = idEmptyBlockX - idX;
        int dy = idEmptyBlockY - idY;

        if ((dx == -1 && dy == 0)
         || (dx == 1 && dy == 0)
         || (dx == 0 && dy == -1)
         || (dx == 0 && dy == 1))
        {
            sfxPlayer.ClickSoundActive();
            score.SetPoint(++countScore);
            SwapBlocks(idX, idY);
            Swap(idX, idY);
            WinCheck();
        }
    }

    private void Swap(int idX, int idY)
    {
        int temp = idBlocks[idX, idY];
        idBlocks[idX, idY] = idBlocks[idEmptyBlockX, idEmptyBlockY];
        idBlocks[idEmptyBlockX, idEmptyBlockY] = temp;

        idEmptyBlockX = idX;
        idEmptyBlockY = idY;
    }

    private void SwapBlocks(int idX, int idY)
    {
        GameObject temp = gameObjects[idX, idY];
        gameObjects[idX, idY] = gameObjects[idEmptyBlockX, idEmptyBlockY];
        gameObjects[idEmptyBlockX, idEmptyBlockY] = temp;
        
        Node clickedNode = gameObjects[idX, idY].GetComponent<Node>();
        Node emptyNode = gameObjects[idEmptyBlockX, idEmptyBlockY].GetComponent<Node>();

        float tempX = clickedNode.X;
        float tempY = clickedNode.Y;
        int tempIdX = clickedNode.IdX;
        int tempIdY = clickedNode.IdY;

        clickedNode.MoveBlock(emptyNode.X, emptyNode.Y, emptyNode.IdX, emptyNode.IdY);
        emptyNode.MoveBlock(tempX, tempY, tempIdX, tempIdY);
    }

    private void WinCheck()
    {
        int value = 0;
        int maxValue = x*y - 1;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (idBlocks[i, j] != value) { return; }
                
                if (value >= maxValue) 
                { 
                    Debug.Log("You Won!"); 
                    panelController.WinPanelEnabled();
                }

                value++;
            }
        }
    }
    #endregion
    private void CreateObject(Node node, int value)
    {
        float coordX = node.X;
        float coordY = node.Y;
        int idX = node.IdX;
        int idY = node.IdY;

        SpriteRenderer sr;

        GameObject obj = gamePrefabs[value];
        obj.GetComponent<Transform>().localPosition = new Vector3(coordX, coordY);
        
        sr = obj.GetComponent<SpriteRenderer>();

        Node objectNode = obj.GetComponent<Node>();
        objectNode.X = coordX;
        objectNode.Y = coordY;
        objectNode.IdX = idX;
        objectNode.IdY = idY;

        objectNode.SetGameManager(this);

        // Вставляем соответсвующий спрайт в наш объект
        sr.sprite = sprites[idBlocks[idX, idY]];

        // Вставляем пустой спрайт в соответсвующий объект
        if (idBlocks[idX, idY] == idBlocks.Length - 1)
        {
           sr.sprite = sprites[sprites.Length - 1];
        }

        gameObjects[idX, idY] = obj;

        // Назначим idEmptyBlockX и idEmptyBlockY соответсвующие координаты id
        if (idBlocks[idX, idY] == idBlocks.Length - 1)
        {
            idEmptyBlockX = idX;
            idEmptyBlockY = idY;
        }
    }
    private void Shuffle()
    {
        int row = x;
        int column = y;

        int temp, t_row, t_column;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                temp = idBlocks[i, j];
                t_row = rnd.Next(row);
                t_column = rnd.Next(column);
                idBlocks[i, j] = idBlocks[t_row, t_column];
                idBlocks[t_row, t_column] = temp;
            }
        }
    }
    private void CreateBlocksSequence()
    {
        int N = firstCoordX+(2*x);
        int M = firstCoordY-(2*y);

        int value = 0;

        for (int j = firstCoordY, idX = 0; j >= M + 2; j-=2, idX++)
        {
            for (int i = firstCoordX, idY = 0; i <= N - 2; i+=2, idY++)
            {
                Node node = CreateNode(i, j, idX, idY, value);
                CreateObject(node, value);

                value++;
            }
        }
    }
    private Node CreateNode(int x, int y, int idX, int idY, int value)
    {
        nodes[value].X = x;
        nodes[value].Y = y;
        nodes[value].IdX = idX;
        nodes[value].IdY = idY;

        return nodes[value];
    }
    #region Initialization blocks data 
    private void Initialization()
    {
        gameObjects = new GameObject[x, y];
        idBlocks = new int[x, y];
    }

    private void SetFieldData()
    {
        x = barleyBreakData.X;
        y = barleyBreakData.Y;
        firstCoordX = barleyBreakData.FirstCoordX;
        firstCoordY = barleyBreakData.FirstCoordY;
    }
    private void DataFilling()
    {
        int  value = 0;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                idBlocks[i, j] = value++;
            }
        }
    }
    #endregion
}
