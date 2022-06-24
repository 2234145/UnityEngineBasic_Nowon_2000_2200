﻿using System;

namespace Example02_Array2D
{
    internal class Program
    {
        // 0은 갈 수 있는 길, 1은 벽
        static int[,] map = new int[5, 5]
        {
            { 0, 0, 0, 0, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 0, 0, 1 ,1 },
            { 1, 1, 0, 0, 0 },
            { 0, 1, 1, 0, 0 }
        };

        static Random randomX = new Random();
        static Random randomY = new Random();
        
        static void Main(string[] args)
        {
            CalcSpawnPoint(out int x, out int y);
            Player player = new Player(x, y);   
            player.MoveLeft(map);
        }

        // 재귀함수 : 함수가 자기자신을 다시 호출하는 형태의 함수
        // out 키워드 : 함수가 반환될 때 두 개 이상의 값을 반환하고자 할 때
        // 인자로 넘겨받은 변수에 연산결과를 반환해서 할당해야할 때 파라미터의 자료형 앞에 쓴다.

        // out 키워드는 해당 함수가 반환 될 때 인자에 값을 할당하는 형태( 즉, 함수가 반환되어야 인자로 넣은 변수의 값이 변함)
        // 함수내에서 값을 할당하는 즉시 변하게 하고싶다. ( 참조형식으로 쓰고싶다면) out 키워드 대신 ref 키워드를 사용하면 된다.
        static void CalcSpawnPoint(out int x , out int y)
        {
            y = randomY.Next(0, map.GetLength(0));
            x = randomX.Next(0, map.GetLength(1));
            
            if (map[y, x] != 0)
                CalcSpawnPoint(out x, out y);
        }
    }

    class Player
    {
        private int _x; // 현재 x 좌표 // 컨트롤 r 눌러서 잘못된 문자 바꿀 수 있다
        private int _y; // 현재 y 좌표

        public Player(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void MoveLeft(int[,] map)
        {
            if (_x - 1 < 0)
            {
                Console.WriteLine($"플레이어를 왼쪽으로 이동시킬 수 없습니다. (맵의 경계)");
            }
            else if (map[_y, _x - 1] == 0)
            {
                _x--;
                Console.WriteLine($"플레이어 왼쪽으로 한칸 이동. 현재 위치 {_x}, {_y}");
            }
            else if (map[_y, _x - 1] == 1)
            {
                Console.WriteLine($"플레이어를 왼쪽으로 이동시킬 수 없습니다. (벽)");
            }
        }
    }
}
