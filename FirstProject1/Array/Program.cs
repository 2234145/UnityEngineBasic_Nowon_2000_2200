﻿using System;

namespace Array
{
    internal class Program
    {
        public int[] 달팽이;


        // array
        // 형태 : 자료형[]
        // 자료형이 정적으로 나열되어있는 형태, 한번 크기를 정하면 일반적으로는 바꿀 수 없다.
        static void Main(string[] args)
        {

            int[] arrInt = new int[3];
            int[] arrInt2 = { 1, 2, 3 };
            Console.WriteLine("Hello World!");
            arrInt = new int[3];
            float[] arrFloat = new float[4];

            // 배열의 인덱스 접근
            // 배열변수이름[인덱스 숫자]
            // : 배열의 가장 첫번째 주소로부터 인덱스숫자 x 배열의 요소의 자료형 크기만큼 뒤에있는 배열요소에 접근
            arrInt[0] = 3;
            arrInt[1] = 2;
            arrInt[2] = 1;
            arrInt = 3;
            Console.WriteLine(arrInt[0]);
            Console.WriteLine(arrInt[1]);
            Console.WriteLine(arrInt[2]);

            String[] arrString = new String[3];
            arrString[0] = "김아무개";
            arrString[1] = "박아무개";
            arrString[2] = "이아무개";

            char[] arrChar = { 'a', 'n', 'd' };
            String tmpString = new String(arrChar);
            Console.WriteLine(tmpString);
            string tmpString2 = "Luke";
            Console.WriteLine(tmpString2[0]);
        }
    }
}
