using System;
using System.Numerics;


const int ROW = 4;
const int COL = 4;
bool[,] isPublic = new bool[ROW, COL];
int[,] board = new int[ROW, COL];
int count = 0;
Random random = new Random();

bool isGameclear = false;

           
CreateBoard(board, ROW, COL);

//---미리보기---

SetBoolBoard(isPublic, true);
PrintBoard(board, isPublic);
Console.WriteLine("시작하려면 아무 키나 누르세요.");
Console.ReadKey(true);
SetBoolBoard(isPublic, false);
//------

PrintBoard(board, isPublic);

while (!isGameclear)
{
    Turn(board, isPublic);
    isGameclear= GameclearCheck(isPublic);
}
Console.WriteLine(new string('=', 34));
Console.WriteLine("게임 종료!");
Console.WriteLine($"시도 횟수: {count}");



void SetBoolBoard(bool[,] boolBoard, bool flag){
    for (int i = 0; i < boolBoard.GetLength(0); i++)
    {
        for (int j = 0; j < boolBoard.GetLength(1); j++)
        {
            boolBoard[i, j] = flag;
        }
    }
}
bool GameclearCheck(bool[,] boolBoard)
{
    for (int i = 0; i < ROW; i++)
    {
        for (int j = 0; j < COL; j++)
        {
            if (!boolBoard[i, j])
            {
                return false;
            }
        }
    }
    return true;
}

void Turn(int[,] numberBoard, bool[,] boolBoard)
{
    var card1 = GetCardNumber(1, boolBoard);
    //Console.WriteLine($"{card1.row} {card1.col}");
    var card2 = GetCardNumber(2, boolBoard);
    //Console.WriteLine($"{card2.row} {card2.col}");

    while (card1 == card2)
    {        
        Console.WriteLine("다른 카드를 입력해주세요");
        card2 = GetCardNumber(2, boolBoard);
    }

    count++;

    if (numberBoard[card1.row, card1.col] == numberBoard[card2.row, card2.col])
    {
        boolBoard[card1.row, card1.col] = true;
        boolBoard[card2.row, card2.col] = true;
        
        
        PrintBoard(numberBoard, boolBoard);
        return;
    }
    else
    {
        boolBoard[card1.row, card1.col] = true;
        boolBoard[card2.row, card2.col] = true;

        
        PrintBoard(numberBoard, boolBoard);

        Console.WriteLine("계속하려면 아무 키나 누르세요.");
        Console.ReadKey(true);

        boolBoard[card1.row, card1.col] = false;
        boolBoard[card2.row, card2.col] = false;

        
        PrintBoard(numberBoard, boolBoard);
    }
         
}



(int row, int col) GetCardNumber(int step, bool[,] boolBoard)
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

        if (boolBoard[row - 1 , col - 1])
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














void CreateBoard(int[,]numberBoard, int rowSize, int colSize)
{
    for (int i = 0; i < rowSize * colSize; i++)
    {
        numberBoard[i / colSize, i % colSize] = i % (rowSize * colSize / 2) +1;
    }
    for (int i = 0;i < random.Next(3, 15); i++)
    {
        int a = random.Next(0, rowSize * colSize);
        int b = random.Next(0, rowSize * colSize);

        int temp =numberBoard[a/colSize, a%colSize];
        numberBoard[a / colSize, a % colSize] = numberBoard[b / colSize, b % colSize];
        numberBoard[b / colSize, b % colSize] = temp;
    }


}



void PrintBoard(int[,] numberBoard, bool[,] boolBoard)
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("======== 카드 맞추기 게임 ========");
    Console.Write($"{"",-5}");
    for (int i =0; i < numberBoard.GetLength(0); i++)
    {
        string colName = $"{i + 1}열";
        Console.Write($"{colName,5}");
    }
    Console.WriteLine();


    for (int i = 0; i < numberBoard.GetLength(0); i++)
    {
        string rowName = $"{i + 1}행";
        Console.Write($"{rowName, -5}");
        for (int j = 0; j < numberBoard.GetLength(1); j++)
        {
            if (boolBoard[i, j])
            {
                Console.Write($"{numberBoard[i, j], 5:D2}");
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