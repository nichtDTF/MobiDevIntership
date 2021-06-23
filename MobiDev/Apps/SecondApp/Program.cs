using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondApp
{
    class Program
    {
        /// <summary>
        /// Board
        /// </summary>
        static protected char[,] board = new char[2,2];

        /// <summary>
        /// Calculate function
        /// </summary>
        static bool Calculate(char key)
        {
            bool flag_Horiz = false;
            bool flag_Vertical = false;
            bool flag_Diag = false;

            //Check all Diagonal Combination
            flag_Diag = ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2])) ||
                        ((board[2, 0] == board[1, 1]) && (board[1, 1] == board[0, 2])) && key == board[0,0];

            for (int i = 0; i < 2; i++)
            {
                //Check all Horizontal Combination
                flag_Horiz = (board[i, 0] == board[i, 1]) && (board[i, 1] == board[i, 2]) && key == board[i, 0];
                //Check all Vertical Combination
                flag_Vertical = (board[0, i] == board[1, i]) && (board[1, i] == board[2, i]) && key == board[0, i];

                if (flag_Vertical || flag_Horiz || flag_Diag)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Check winner
        /// </summary>
        protected static void CheckWinner()
        {
            if (!Calculate('O'))
                if (!Calculate('X'))
                    Console.WriteLine("''");
                else
                    Console.WriteLine('X');
            else
                Console.WriteLine('O');
            Console.WriteLine();
        }

        /// <summary>
        /// Output Information
        /// </summary>
        static void Output()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");

        }


        /// <summary>
        /// main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char[,] sit_x_win = {{'X', 'O', 'X'}, {'X', 'O', 'O'}, {'X', 'X', 'O'}};
            board = sit_x_win;
            Output();
            CheckWinner();

            char[,] sit_o_win = { { 'O', 'X', 'O' }, { 'X', 'O', 'O' }, { 'X', 'X', 'O' } };
            board = sit_o_win;
            Output();
            CheckWinner();

            char[,] no_one_win = { { 'X', 'O', 'X' }, { 'O', 'O', 'X' }, { 'X', 'X', 'O' } };
            board = no_one_win;
            Output();
            CheckWinner();
            
            Console.ReadLine();
        }

    }
}
