using System;
///<summary>
///Este programa cria um Array Bidimensional de 5x5 e faz print. Verifica e mete as casas especiais do jogo
///com as suas restrições e impede de meter essas casas no início e no fim e se já houver uma casa especial nessa posição.
///<summary>
class Board{
    ///Cria um array bidimensional de 5x5 chamado Board e é divido em par e ímpar.
    Random random = new Random();

    public Random GetRandom(){ ///Serve par gerar números randoms diferentes para os jogadores.
        return random;
    }
    private String[,] Matrix = new String[5,5]; ///Array bidimensional de 5x5.
    public Board(int numSnakes, int numLadders){
        for(int i = Matrix.GetLength(0) - 1; i>=0; i-- ){
            for(int j = 0; j < Matrix.GetLength(1); ++j){
                if(i%2 == 0){
                    Matrix[i,j] = ((i*5) + (j + 1)).ToString(); ///Se as linhas forem pares.
                }else{
                    Matrix[i,j] = ((i*5) + (5 - j)).ToString(); ///Se as linhas forem ímpares.
                }
            }
        }
        GenerateSpecialCases();
    }
    ///Faz print do array bidimensional chamado Board.
    public void Print(){
       for(int i = Matrix.GetLength(0) - 1; i>=0; i-- ){
            for(int j = 0; j < Matrix.GetLength(1); ++j){
                Console.Write("[ {0} ]", Matrix[i,j]);
            }
            Console.WriteLine();
       }
       ///Faz print no ecrã as teclas do jogo e o que cada letra é no jogo.
       Console.WriteLine("Player Keys: D (Roll dice), E(Roll extra dice if any), C(Roll cheat dice if any)");
       Console.WriteLine("S = Snake | C = Cobra | H = Ladder | B = Boost | U = U-Turn | O = Extra Dice | Q = Cheat Dice");
    }

    ///Recebe valores das posições e verifica se forem fora do array deixa como vazio.
    public String GetValueAtPosition(int PositionX, int PositionY){
        if(PositionX < 0 || PositionX >= Matrix.GetLength(0) + 1 || PositionY < 0 || PositionY >= Matrix.GetLength(1) + 1){
            return "";
        }

        return Matrix[PositionX,PositionY];
    }

    ///Gerador para gerar novas posições random para as casas especiais.
    public int[] GetValidPlaceablePosition(int MinRow, int MaxRow, int MinCol, int MaxCol){
        int PositionX = random.Next(MinRow, MaxRow);
        int PositionY = random.Next(MinCol, MaxCol);
        while(!CanPlaceSpecialCase(PositionX, PositionY)){
                PositionX = random.Next(MinRow, MaxRow);
                PositionY = random.Next(MinCol, MaxCol);
        }

        return new int[2]{PositionX, PositionY};
    }

    ///Gera posições random para as casas especiais seguindo as suas restrições.
    ///Cada Casa especial tem uma letra designada para se identificar.
    ///<remarks>
    ///Snakes = S.
    ///Ladders = H.
    ///Cobra = C.
    ///Boost = B.
    ///U-Turn = U.
    ///ExtraDie = O.
    ///CheatDie = Q.
    ///<remarks>
    private void GenerateSpecialCases(){
        int Snakes = random.Next(2, 4);
        int Ladders = random.Next(2, 4);
        int Cobra = 1;
        int Boost = random.Next(0, 2); 
        int Uturn = random.Next(0, 2);
        int ExtraDie = 1;
        int CheatDie = 1;
        int[] Position;

        for( int i = 0; i < Cobra; i++){
            Position = GetValidPlaceablePosition(2, 4, 0, 4);
            Matrix[Position[0], Position[1]] = "C";
        }

        for( int i = 0; i < Snakes; i++ ){
           Position = GetValidPlaceablePosition(1, 4, 0, 4);
           Matrix[Position[0], Position[1]] = "S";     
        }

         for( int i = 0; i < Ladders; i++ ){
            Position = GetValidPlaceablePosition(0, 3, 0, 4);
            if(GetValueAtPosition(Position[0] + 1, Position[1]) == "S"){
                i--;
                continue;
            }
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

    ///Função que aplica os efeitos das casas especiais quando o jogador cair nela.
    public void ApplySpecialCase(Player p, String Case){
        if(Case == "C"){
            p.SetPos(0, 0);
        }
        else if(Case == "S"){
            p.SetPos(p.GetPos()[0] - 1, p.GetPos()[1]);
        }
        else if(Case == "H"){
            p.SetPos(p.GetPos()[0] + 1, p.GetPos()[1]);
        }
        else if(Case == "B"){
            p.Movement(this, 2);
        }
        else if(Case == "U"){
            p.Movement(this, -2);
        }
        else if(Case == "O"){
            p.SetExtraDie(true);
            Console.WriteLine("Player {0} won an Extra Die.", p.GetId()); 
        }
        else if(Case == "Q"){
            p.SetCheatDie(true);
            Console.WriteLine("Player {0} won a Cheat Die.", p.GetId());
        }
    }

    ///Verifica onde pode meter as casas especiais. 
    ///Sendo estas as restrições: a primeira casa e a última casa e fora do array.
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

    ///Verifica se é uma posição normal.
    public bool IsNormalPosition(Player p, int PositionX, int PositionY){
        if(GetValueAtPosition(PositionX, PositionY) == "O" && p.GetExtraDie()){
            return true;
        }
         if(GetValueAtPosition(PositionX, PositionY) == "Q" && p.GetCheatDie()){
            return true;
        }
        int val;
        return int.TryParse(GetValueAtPosition(PositionX, PositionY), out val);
        
    }

    ///Função que pergunta se o jogador já ganhou quando chega a casa 25
    public bool HasPlayerWon(Player p){
        return p.GetPos()[0] == 4 && p.GetPos()[1] == 4;
    }
}
///<summary>
///Cria os dois jogadores do jogo e o seu movimento e o gera os valores que saiam dos dados.
///<summary>
    class Player{
        private int id; ///os ID dos jogadores.
        private int[] pos = new int[2]; ///posições dos jogadores.
        private bool HasExtraDie = false;
        private bool HasCheatDie = false;

        ///Função getter para o Extra Die.
        public bool GetExtraDie(){
            return HasExtraDie;
        }

        ///Função setter para o Extra Die.
        public void SetExtraDie(bool NewExtraDie){
            HasExtraDie = NewExtraDie;
        }

        ///Função getter para o Cheat Die.
        public bool GetCheatDie(){
            return HasCheatDie;
        }

        ///Função setter para o Cheat Die.
        public void SetCheatDie(bool NewCheatDie){
            HasCheatDie = NewCheatDie;
        }

        ///Busca o ID dos jogadores.
        public int GetId(){
            return id;
        }

        ///Busca as posições dos jogadores.
        public int[] GetPos(){
            return pos;
        }

        ///Põe a posição dos jogadores.
        public void SetPos(int NewPosX, int NewPosY){
            pos[0] = NewPosX;
            pos[1] = NewPosY;
        }

        ///Informação dos jogadores e as suas posições.
        public Player(int _id){
            id = _id;
            pos[0] = 0;
            pos[1] = 0;
        }

        ///Permite o jogador mover para trás.
        private void MovementBackwards(Board MovementBoard, int backwardsteps)
        {
            for( int i = 0; i < backwardsteps; i++){
                if(pos[0] == 0 && pos[1] == 0){
                    return;
                }
                if(pos[0]%2 == 0){
                    if(pos[1] == 0){
                        pos[0] -= 1;
                    }
                    else{
                        pos[1] -= 1;
                    }
                }
                else{
                    if(pos[1] == 4){
                        pos[0] -= 1;
                    }
                    else{
                        pos[1] += 1;
                    }
                }
            }
        }

        ///Permite o jogador andar para frente.
        public void Movement(Board MovementBoard, int steps ){
            if(steps < 0){
                MovementBackwards(MovementBoard, -steps);
                return;
            }
            for( int i = 0; i < steps ; i++){
                if(pos[0] == 4 && pos[1] == 4){
                    MovementBackwards(MovementBoard, steps - i);
                    return;
                }

                if(pos[0]%2 == 0){
                    if(pos[1] == 4){
                        pos[0] += 1;
                    }
                    else{
                        pos[1] += 1;
                    }

                }
                else{
                    if(pos[1] == 0){
                        pos[0] += 1;
                    }
                    else{
                        pos[1] -= 1;
                    }
                }
                
            }
        }

        ///Lança um dado de 6.
        public int RollDice(Random random){
            return random.Next(1,6);
        }

        ///Lança o Extra Die.
        public int RollExtraDice(Random random){
            return RollDice(random) + RollDice(random);
        }

        ///Lança o Cheat Die.
        public int RollCheatDice(){
            return 
        }
    }

    ///<summary>
    ///Começa o jogo e cria um game loop até alguém ganhar.
    ///<summary>
    class SnakesAndLadders{
        static void Main(string[] args)
        {
            String[] AvailablePlays = new String[3]{"D", "E", "C"};
            Player p1 = new Player(1);
            Player p2 = new Player(2);
            Board b = new Board(0,0);
            bool HasGameEnded = false;
            int Turn = 0;
            while(!HasGameEnded){
                b.Print();
                Player PlayerPlaying;
                if(Turn % 2 == 0){
                    PlayerPlaying = p1;
                }else{
                    PlayerPlaying = p2; 
                }
                Console.WriteLine("Player {0} is playing", PlayerPlaying.GetId());
                String Play = Console.ReadLine();
                while(!Array.Exists(AvailablePlays, p => p == Play)){
                    Play = Console.ReadLine();
                }
                if(Play == "D"){
                    int roll = PlayerPlaying.RollDice(b.GetRandom());
                    PlayerPlaying.Movement(b,roll);
                    Console.WriteLine("Player {0} rolled {1}", PlayerPlaying.GetId(), roll);
                }
                else if(Play == "E" && PlayerPlaying.GetExtraDie()){
                    int roll = PlayerPlaying.RollExtraDice(b.GetRandom());
                    PlayerPlaying.Movement(b,roll);
                    PlayerPlaying.SetExtraDie(false);
                    Console.WriteLine("Player {0} rolled extra dice with a sum of {1}", PlayerPlaying.GetId(), roll);
                }
                while(!b.IsNormalPosition(PlayerPlaying, PlayerPlaying.GetPos()[0], PlayerPlaying.GetPos()[1])){
                    b.ApplySpecialCase(PlayerPlaying, b.GetValueAtPosition(PlayerPlaying.GetPos()[0], PlayerPlaying.GetPos()[1]));
                }

                if(Turn % 2 == 0){
                    if(PlayerPlaying.GetPos() == p2.GetPos()){
                        p2.Movement(b, -1);
                    }
                }else{
                    if(PlayerPlaying.GetPos() == p1.GetPos()){
                        p1.Movement(b, -1);
                    }
                }

                Console.WriteLine("Player {0} is now at {1}", PlayerPlaying.GetId(), b.GetValueAtPosition(PlayerPlaying.GetPos()[0], PlayerPlaying.GetPos()[1]));
                HasGameEnded = b.HasPlayerWon(PlayerPlaying);
                Turn++;
            }
        }
    }
