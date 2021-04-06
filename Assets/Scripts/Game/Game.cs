using UnityEngine;
using System;

public class Game : MonoBehaviour
{
#region Singleton
    private static Game _instance;
    public static Game Instance => _instance;
#endregion

    [SerializeField] private Block prefabBlock;
    [SerializeField] private Sprite[] sprites;
    private BarleyBreakData barleyBreakData;
    public int CameraSize => barleyBreakData.CameraSize;
    private Texture2D texture;
    public Block[,] Blocks { get; private set; }
    private int[] shuffleIds;
    private static System.Random rnd;
#region Events
    public event Action<int> OnChangeScoreEvent;
    public event Action OnWonEvent;
#endregion
    public bool gameOver = false;
    private int countScore = 0;

#region Main Functions
    private void Awake()
    {
        if (_instance != null) return;
        _instance = this;

        Initialization();
    }
    private void Start()
    {
        texture = Resources.Load<Texture2D>("Barley");
        sprites = Resources.LoadAll<Sprite>(texture.name);

        // создаем все блоки на сцене
        CreateBlocks();
        // Тасуем массив чтобы наши блоки расположились в рандомном порядке
        Shuffle();
        // заполняем блоки значениями (данными) и за одно подпишем MoveBlock на все блоки
        FillBlocksWithData();
    }
#endregion
#region  ResetGame
    public void ResetGame()
    {
        gameOver = false;
        countScore = 0;
        OnChangeScoreEvent?.Invoke(0);
        Shuffle();
        FillBlocksWithData();
    }
#endregion
    private void Initialization()
    {
        barleyBreakData = SelectedField.BarleyBreakData;
        Blocks = new Block[barleyBreakData.Cols, barleyBreakData.Rows];
        shuffleIds = new int[barleyBreakData.SizeField];
        rnd = new System.Random();
    }
#region Main Functions
    private void CreateBlocks()
    {
        int i = 0;
        for (int x = 0; x < barleyBreakData.Cols; x++)
        {
            for (int y = 0; y < barleyBreakData.Rows; y++)
            {
                Blocks[x, y] = Instantiate(prefabBlock);
                shuffleIds[i] = i++;
            }
        }
    }
    private void FillBlocksWithData()
    {
        int id = 0;
        int firstPosX = barleyBreakData.FirstPosX;
        int firstPosY = barleyBreakData.FirstPosY;

        for (int x = 0, posY = firstPosY; x < barleyBreakData.Cols; x++, posY -= 2)
        {
            for (int y = 0, posX = firstPosX; y < barleyBreakData.Rows; y++, posX += 2)
            {
                Blocks[x, y].OnChangePlaceBlockEvent += MoveBlock;
                Blocks[x, y].Init(shuffleIds[id], x, y, posX, posY, sprites[shuffleIds[id]]);

                if (shuffleIds[id] == shuffleIds.Length - 1)
                {
                    Blocks[x, y].Init(shuffleIds[id], x, y, posX, posY, sprites[sprites.Length - 1]);
                    idEmptyBlockX = x;
                    idEmptyBlockY = y;
                }
                id++;
            }
        }
    }
    private void Shuffle()
    {
        int size = shuffleIds.Length;

        int t_size, temp;

        for (int i = 0; i < size; i++)
        {
            temp = shuffleIds[i];

            t_size = rnd.Next(size);

            shuffleIds[i] = shuffleIds[t_size];
            shuffleIds[t_size] = temp;
        }
    }
#endregion

#region Move Blocks Event
    int idEmptyBlockX;
    int idEmptyBlockY;
    private void MoveBlock(Block block)
    {
        if (gameOver) { return; }

        int dx = idEmptyBlockX - block.IdX;
        int dy = idEmptyBlockY - block.IdY;

        if ((dx == -1 && dy == 0)
         || (dx == 1 && dy == 0)
         || (dx == 0 && dy == -1)
         || (dx == 0 && dy == 1))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.AUDIO_clickSFX);
            OnChangeScoreEvent?.Invoke(++countScore);
            SwapData(block);
            WinCheck();
        }
    }
    private void SwapData(Block block)
    {
        Sprite sp_temp = block.Icon;
        int id_temp = block.Id;

        block.Icon = Blocks[idEmptyBlockX, idEmptyBlockY].Icon;

        block.Id = Blocks[idEmptyBlockX, idEmptyBlockY].Id;
        Blocks[idEmptyBlockX, idEmptyBlockY].Icon = sp_temp;

        Blocks[idEmptyBlockX, idEmptyBlockY].Id = id_temp;

        idEmptyBlockX = block.IdX;
        idEmptyBlockY = block.IdY;
    }
    private void WinCheck()
    {
        int id = 0;
        for (int i = 0; i < barleyBreakData.Cols; i++)
        {
            for (int j = 0; j < barleyBreakData.Rows; j++)
            {
                if (Blocks[i, j].Id != id)
                {
                    return;
                }
                Debug.Log(Blocks[i, j].Id + " " + id);
                id++;
            }
        }
        OnWonEvent?.Invoke();
        gameOver = true;
    }
#endregion
}
