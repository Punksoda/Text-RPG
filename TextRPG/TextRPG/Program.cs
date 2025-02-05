namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args) // 메인함수로, 게임의 시작입니다! 
        {
            Player player = new Player("Chad", "전사", 10, 5, 100, 1500); // 플레이어를 메인에 생성하고, 초기화합니다
            Inventory inventory = new Inventory(); // 인벤토리를 메인에 생성하고, 초기화합니다
            Store store = new Store(player); // 상점을 메인에 생성하고, 초기화합니다

            while (true) // 게임이 종료될 때까지 반복하고, 잘못된 입력이 나오면 초기화면으로 돌아가게끔 동작합니다
            {

                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다\n");


                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");

                if (int.TryParse(Console.ReadLine(), out int number)) // 입력받은 값이 숫자인지 확인하고, 해당 숫자에 따라 player, inventory, store를 호출합니다.
                {
                    {
                        if (number == 1)
                        {
                            player.ShowStatus();
                        }
                        else if (number == 2)
                        {
                            inventory.ShowInventory();
                            Console.Write("\n원하시는 행동을 입력해주세요: ");
                            string input = Console.ReadLine();
                            if (input == "1")
                            {
                                inventory.ManageEquipment();
                            }
                            else if (input == "2")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadKey();
                            }
                        }
                        else if (number == 3)
                        {
                            store.ShowStore();
                            Console.Write("\n원하시는 행동을 입력해주세요: ");
                            string input = Console.ReadLine();
                            if (input == "1")
                            {
                                store.PurchaseItem();
                            }
                            else if (input == "2")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.\n");
                        }
                    }
                }
            }


        }
    }
}


