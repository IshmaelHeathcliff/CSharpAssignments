using System;
using System.Threading;
using System.Text;


public class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            Map a = new Map();
            a.Start();
            Console.WriteLine("c键继续，其他键退出：");
            char con = Console.ReadKey().KeyChar;
            if(con != 'c') break;
        }

    }
}


public class Map
{
    const int row = 10;
    const int col = 31;
    int dif = 300;
    int dw = col / 2;
    int counts = 0;
    int[,] gameMap = new int[row, col];
    Random r = new Random();
    bool isNormal = true;

    private void falling() // 火箭落下
    {
        for(int i=0; i < row-1; i++)
        {
            for(int j=0; j < col; j++) this.gameMap[row-1-i,j] = this.gameMap[8-i,j];
        }

        for(int i=0; i < col; i++) this.gameMap[0, i] = 0;
        int n = r.Next(0,5);
        for(int i=0; i < n; i++) this.gameMap[0, r.Next(0,col)] = r.Next(4,16);
        counts += 1;
        if (this.gameMap[row-1,this.dw] != 0) gameover();
    }

    private void move()
    {
        char c = new char();
        c = Console.ReadKey(true).KeyChar;
        if (c == 'a' && this.dw != 1) dw -= 1;
        else if (c == 'd' && this.dw != col-2) dw += 1;

        if (this.gameMap[row-1,this.dw] > 3) gameover();
    }

    private void gameover()
    {
        isNormal = false;
    }

    private void drawMap()
    {
        string ob = " (o)^@*&+%$#!.;-";
        Console.Clear();
        StringBuilder mapbuffer = new StringBuilder();
        mapbuffer.Append("下落火箭\n");
        int[,] gameMapCp = (int[,])this.gameMap.Clone();
        gameMapCp[row-1,this.dw] = 2;
        gameMapCp[row-1,this.dw-1] = 1;
        gameMapCp[row-1,this.dw+1] = 3;

        for(int i=0; i<row; i++)
        {
            for(int j=0; j<col; j++)
            {
                mapbuffer.Append(ob[gameMapCp[i,j]]);
            }
            mapbuffer.Append("\n");
        }
        Console.WriteLine(mapbuffer.ToString());
        Console.WriteLine("目前分数为{0}", counts);
        if(isNormal == false) Console.WriteLine("Game Over!任意键结束\n");
    }

    private void mapfalling()
    {
         while(isNormal)
        {
            falling();
            drawMap();
            Thread.Sleep((dif-counts) > (dif/10) ? (dif-counts) : (dif/10));
        }
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("按下a,d左右移动，避开火箭");
        Console.Write("选择难度后开始，e简单，n正常，d困难：");
        char c = Console.ReadKey().KeyChar;
        switch (c)
        {
            case 'e': dif = 300; break;
            case 'n': dif = 200; break;
            case 'd': dif = 100; break;
        }

        Thread t = new Thread(mapfalling);
        t.Start();

        while(isNormal)
        {
            move();
            drawMap();
        }
    }
}
