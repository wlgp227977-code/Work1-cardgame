using System;


const int ROW = 4;
const int COL = 4;
bool[,] isPublic = new bool[ROW, COL];
int[,] board = new int[ROW, COL];
int count = 0;
Random random = new Random();

bool isGameover = false;

           
CreateBoard();

//---미리보기---
for (int i = 0; i < ROW; i++)
{
    for (int j = 0; j < COL; j++)
    {        
        isPublic[i, j] = true;
    }
}
PrintBoard();
Console.WriteLine("시작하려면 아무 키나 누르세요.");
Console.ReadKey(true);

for (int i = 0; i < ROW; i++)
{
    for (int j = 0; j < COL; j++)
    {
        isPublic[i, j] = false;
    }
}
//------

PrintBoard();

while (!isGameover)
{
    Turn();
    isGameover= GameoverCheck();
}
Console.WriteLine(new string('=', 34));
Console.WriteLine("게임 종료!");
Console.WriteLine($"시도 횟수: {count}");


bool GameoverCheck()
{
    for (int i = 0; i < ROW; i++)
    {
        for (int j = 0; j < COL; j++)
        {
            if (!isPublic[i, j])
            {
                return false;
            }
        }
    }
    return true;
}

void Turn()
{
    var card1 = GetCardNumber(1);
    //Console.WriteLine($"{card1.row} {card1.col}");
    var card2 = GetCardNumber(2);
    //Console.WriteLine($"{card2.row} {card2.col}");

    while (card1 == card2)
    {        
        Console.WriteLine("다른 카드를 입력해주세요");
        card2 = GetCardNumber(2);
    }

    count++;

    if (board[card1.row, card1.col] == board[card2.row, card2.col])
    {
        isPublic[card1.row, card1.col] = true;
        isPublic[card2.row, card2.col] = true;
        
        
        PrintBoard();
        return;
    }
    else
    {
        isPublic[card1.row, card1.col] = true;
        isPublic[card2.row, card2.col] = true;

        
        PrintBoard();

        Console.WriteLine("계속하려면 아무 키나 누르세요.");
        Console.ReadKey(true);

        isPublic[card1.row, card1.col] = false;
        isPublic[card2.row, card2.col] = false;

        
        PrintBoard();
    }
         
}





(int row, int col) GetCardNumber(int step)
{
    int row = 0;
    int col = 0;
    string msg = step switch
    {
        1 => "첫 번째 카드 위치를 입력하세요. (행 열): ",
        2 => "두 번째 카드 위치를 입력하세요. (행 열): ",
        _ => "오류"
    };
    while (true)
    {
        Console.Write(msg);
        string input = Console.ReadLine().Trim();
        string[] parts = input.Split(' ');
        if (parts.Length != 2 || !int.TryParse(parts[0], out row) || !int.TryParse(parts[1], out col) || 
            row < 1 || row > ROW || col < 1 || col > COL)
        {
            Console.WriteLine("행과 열을 공백으로 구분하여 정수로 입력하세요.");
            Console.WriteLine($"* 행은 1~{ROW}, 열은 1~{COL} 범위.");
            continue;
        }

        if (isPublic[row - 1 , col - 1])
        {
            Console.WriteLine("이미 맞춘 카드입니다.");
            continue;
        }
        else
        {
            return (row-1, col-1);
        }
        
    }
   
}














void CreateBoard()
{    
    int[] nums = new int [ROW * COL];
    for (int i = 0; i < ROW * COL; i++)
    {
        nums[i] = i % (ROW * COL / 2);
        Console.Write(nums[i]);        
    }   Console.WriteLine();

    for (int i = 0;i < random.Next(3, 15); i++)
    {
        int a = random.Next(0, ROW * COL);
        int b = random.Next(0, ROW * COL);

        int temp = nums[a];
        nums[a] = nums[b];
        nums[b] = temp;
    }
    for (int i = 0; i < ROW * COL; i++)
    {
        Console.Write(nums[i]);
    }

    for (int i = 0; i < ROW; i++)
    {
        for (int j = 0; j < COL; j++)
        {
            board[i, j] = nums[i * COL + j] + 1;
            isPublic[i, j] = false;
        }
    }

    
}



void PrintBoard()
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("======== 카드 맞추기 게임 ========");
    Console.Write($"{"",-5}");
    for (int i =0; i < COL; i++)
    {
        string colName = $"{i + 1}열";
        Console.Write($"{colName,5}");
    }
    Console.WriteLine();


    for (int i = 0; i < ROW; i++)
    {
        string rowName = $"{i + 1}행";
        Console.Write($"{rowName, -5}");
        for (int j = 0; j < COL; j++)
        {
            if (isPublic[i, j])
            {
                Console.Write($"{board[i, j], 5:D2}");
            }
            else
            {
                Console.Write($"{"**",5}");
            }
        }Console.WriteLine();

    }
    Console.WriteLine();
    //Console.WriteLine($"시도 횟수: {count}");
}