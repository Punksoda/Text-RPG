namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Chad", "전사", 10, 5, 100, 1500);
            Inventory inventory = new Inventory();
            Store store = new Store(player);
            while (true)
            {

                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다\n");


                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점\n");

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");

                if (int.TryParse(Console.ReadLine(), out int number))
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


