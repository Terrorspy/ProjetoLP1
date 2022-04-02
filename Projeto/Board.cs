using System;
class Board{
    Random random = new Random();
    private String[,] Matrix = new String[5,5];
    public Board(int numSnakes, int numLadders){
        for(int i = Matrix.GetLength(0) - 1; i>=0; i-- ){
            for(int j = 0; j < Matrix.GetLength(1); ++j){
                if(i%2 == 0){
                    Matrix[i,j] = ((i*5) + (j + 1)).ToString();
                }else{
                    Matrix[i,j] = ((i*5) + (5 - j)).ToString();
                }
            }
        }
        GenerateSpecialCases();
    }
    public void Print(){
       for(int i = Matrix.GetLength(0) - 1; i>=0; i-- ){
            for(int j = 0; j < Matrix.GetLength(1); ++j){
                Console.Write("[ {0} ]", Matrix[i,j]);
            }
            Console.WriteLine();
       }
    }

    public String GetValueAtPosition(int PositionX, int PositionY){
        if(PositionX < 0 || PositionX >= Matrix.GetLength(0) + 1 || PositionY < 0 || PositionY >= Matrix.GetLength(1)+1){
            return "";
        }

        return Matrix[PositionX,PositionY];
    }

    public int[] GetValidPlaceablePosition(int MinRow, int MaxRow, int MinCol, int MaxCol){
        int PositionX = random.Next(MinRow, MaxRow);
        int PositionY = random.Next(MinCol, MaxCol);
        while(!CanPlaceSpecialCase(PositionX, PositionY)){
                PositionX = random.Next(MinRow, MaxRow);
                PositionY = random.Next(MinCol, MaxCol);
        }

        return new int[2]{PositionX, PositionY};
    }

    private void GenerateSpecialCases(){
        int Snakes = random.Next(2, 4);
        int Ladders = random.Next(2, 4);
        int Cobra = 1;
        int Boost = random.Next(0, 2); 
        int Uturn = random.Next(0, 2);
        int ExtraDie = 1;
        int CheatDie = 1;

        int[] Position = GetValidPlaceablePosition(2, 4, 0, 4);
        Matrix[Position[0], Position[1]] = "C";
        

        for( int i = 0; i < Snakes; i++ ){
           Position = GetValidPlaceablePosition(1, 4, 0, 4);
           Matrix[Position[0], Position[1]] = "S";     
        }

         for( int i = 0; i < Ladders; i++ ){
            Position = GetValidPlaceablePosition(0, 3, 0, 4);
            Matrix[Position[0], Position[1]] = "H";      
        }
        for( int i = 0; i < Boost; i++ ){
            Position = GetValidPlaceablePosition(0, 3, 0, 4);
            Matrix[Position[0], Position[1]] = "B";
        }
        for ( int i = 0; i < Uturn; i++ ){
            Position = GetValidPlaceablePosition(1, 4, 0, 4);
            Matrix[Position[0], Position[1]] = "U";
        }
        for ( int i = 0; i < ExtraDie; i++ ){
            Position = GetValidPlaceablePosition(0, 4, 0, 4);
            Matrix[Position[0], Position[1]] = "O";
        }
        for ( int i = 0; i < CheatDie; i++ ){
            Position = GetValidPlaceablePosition(0, 4, 0, 4);
            Matrix[Position[0], Position[1]] = "Q";
        }

    }

    private bool CanPlaceSpecialCase(int PositionX, int PositionY){
        if(PositionX == 4 && PositionY == 4){
            return false;
        }
        if (PositionX == 0 && PositionY == 0){
            return false;
        }
        int val;
        if ( int.TryParse(GetValueAtPosition(PositionX, PositionY), out val)){
            return true;
        }
        return false;
    }

    private bool IsNormalPosition(int PositionX, int PositionY){
        int val;
        return int.TryParse(GetValueAtPosition(PositionX, PositionY), out val);
        
    }
}

    class Player{
        private int id;
        private int[] pos = new int[2];
        public int GetId(){
            return id;
        }

        public int[] GetPos(){
            return pos;
        }

        public void SetPos(int[] NewPos){
            pos = NewPos;
        }

        Random random = new Random();

        public Player(int _id){
            id = _id;
            pos[0] = 0;
            pos[1] = 0;
        }
        public int RollDice(){
            return random.Next(1,6);
        }
    }
    class SnakesAndLadders{
        static void Main(string[] args)
        {
            Player p1 = new Player(1);
            Player p2 = new Player(2);
            Board b = new Board(0,0);
            b.Print();
 
        }
    }
