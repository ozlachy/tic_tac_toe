using System;
namespace tiktaktok
{
    class Program
    {
        static void Main(string[] args)
        {      
            string[] board = {"[ 1 ]","[ 2 ]","[ 3 ]","[ 4 ]","[ 5 ]","[ 6 ]","[ 7 ]","[ 8 ]","[ 9 ]"};
            int[] used = {-1,-1,-1,-1,-1,-1,-1,-1,-1};

            //start the game
            bool play = false;
            while (play == false)
            {
                Console.Write("Start Y/N: ");
                string start = Console.ReadLine();
                switch(start.ToLower())
                {
                    case "yes":
                    case "y":
                        play = true;
                        break;
                    case "no":
                    case "n":
                        play = false;
                        break;
                } 
            }

            Random rnd = new Random();
            string playerType = "error";
            string computerType = "error";
            int randomType = rnd.Next(0,2);
            int move = 0;
            string thing = "[" + playerType + "]";
            string whowon = "noone";
            switch(randomType)
            {
                case 0:
                    playerType = "X";
                    computerType = "O";
                    break;
                case 1:
                    computerType = "X";
                    playerType = "O";
                    break;
            }

            Console.WriteLine("\nYou are " + playerType + "'s.");

            int winCondition = 0;


            while (winCondition == 0)
            {
            var values = player(playerType,board,move,used);
            board = values.Item1;
            used = values.Item2;
            move++;
            whowon = "player";
            winCondition = checkwin(board);
            if (winCondition != 0) break;
            values = computer(computerType,board,move,used);
            board = values.Item1;
            used = values.Item2;
            move++;       
            whowon = "computer";
            winCondition = checkwin(board);
            }

            if (winCondition == -1)
            {
                Console.WriteLine("It's a tie");
            }
            else if (winCondition == 1 && whowon == "player")
            {
                Console.WriteLine("\nYOU WON!");
                makeboard(board);
            }
            else if (winCondition == 1 && whowon == "computer")
            {
                Console.WriteLine("\nCOMPUTER WON!");
                makeboard(board);
            }
            Console.ReadKey();

        }

        static void makeboard(string[] board)
        {  
            Console.WriteLine("\n---------------");

            for (int i = 0; i < 9; i += 3)
            {
                Console.WriteLine(board[i] + board[i+1] + board[i+2]);
            }

            Console.WriteLine("---------------");

        }
        
        static (String[], int[])  computer(string computerType, string[] board, int move, int[] used)
        {
            bool alreadyused = false;         
            Random rnd = new Random();
            int input = rnd.Next(1,10);          
            for (int i = 0; i < 9; i++)
            {   
                if (used[i] == input && alreadyused == false)
                {
                    alreadyused = true;
                }
            }



 
            while(alreadyused == true)
            {
                
                input = rnd.Next(1,10);
                
                for (int i = 0; i < 9; i++)
                {   
                    if (used[i] == input)
                    {
                        alreadyused = true;
                    }
                    if (used[0] != input && used[1] != input && used[2] != input && used[3] != input && used[4] != input && used[5] != input && used[6] != input && used[7] != input && used[8] != input)
                    {
                        alreadyused= false;
                    }
                }
            }
       
            used[move] = input;
            input--;
            board[input] = "[ " + computerType + " ]";


            return (board,used);
 
            
        }



        static (String[], int[])  player(string type, string[] board, int move, int[] used)
        {                 

            bool alreadyused = false;
            makeboard(board);          
            Console.Write("\nPlease enter where you would like to go from 1 - 9: ");

            int input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 9; i++)
            {   
                if (used[i] == input && alreadyused == false)
                {
                    alreadyused = true;
                }
            }


            while(alreadyused == true)
            {
                Console.WriteLine("\nYou can't go here choose another space");
                makeboard(board);
                input = Convert.ToInt32(Console.ReadLine());
                
                for (int i = 0; i < 9; i++)
                {   
                    if (used[i] == input)
                    {
                        alreadyused = true;
                    }
                    if (used[0] != input && used[1] != input && used[2] != input && used[3] != input && used[4] != input && used[5] != input && used[6] != input && used[7] != input && used[8] != input)
                    {
                        alreadyused = false;
                    }
                }
            }
            
            used[move] = input;
            input--;
            board[input] = "[ " + type + " ]";

            return (board,used);
 
            
        }

        static int checkwin(string[] board)
        {   

            if (board[0] == board[1] && board[1] == board[2])
            {
                return 1;
            }
            else if (board[3] == board[4] && board[4] == board[5])
            {
                return 1;
            }
            else if (board[6] == board[7] && board[7] == board[8])
            {
                return 1;
            }
            else if (board[0] == board[3] && board[3] == board[6])
            {
                return 1;
            }
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return 1;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return 1;
            }
            else if (board[0] == board[4] && board[4] == board[8])
            {
                return 1;
            }
            else if (board[2] == board[4] && board[4] == board[6])
            {
                return 1;
            }
            else if (board[0] != "[ 1 ]" && board[1] != "[ 2 ]" && board[2] != "[ 3 ]" && board[3] != "[ 4 ]" && board[4] != "[ 5 ]" && board[5] != "[ 6 ]" && board[6] != "[ 7 ]" && board[7] != "[ 8 ]" && board[8] != "[ 9 ]")
            {
                return -1;
            }
            else
            {

                return 0;

            }


        }
    }
}