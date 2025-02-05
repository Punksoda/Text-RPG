public class Item
{
    public string Name { get; set; } // 아이템 이름
    public string Type { get; set; } // 아이템 형식
    public int Value { get; set; } // 아이템 능력치
    public string Description { get; set; } // 아이템 설명
    public int Price { get; set; } // 아이템 가격
    public bool IsEquip { get; set; } // 아이템 장착 여부
    public bool IsPurchased { get; set; } // 아이템 구매 여부


    public Item(string name, string type, int value, string description, int price = 0) // 새로운 아이템 생성
    {
        Name = name;
        Type = type;
        Value = value;
        Description = description;
        Price = price;
        IsEquip = false; // 장착이 안된 상태로 인스턴스 초기화
        IsPurchased = false; // 구매가 안된 상태로 인스턴스 초기화
    }

    public void ToggleEquip() // 장착 상태 변경
    {
        IsEquip = !IsEquip;
    }

    public void TogglePurchase() // 구매 상태 변경
    {
        IsPurchased = !IsPurchased;
    }

}

class Inventory
{
    private List<Item> Invenitems; //아이템 목록

    public Inventory() // 인벤토리 초기화
    {
        Invenitems = new List<Item>
        {
            new Item("무쇠갑옷", "방어력", +5, "무쇠로 만들어져 튼튼한 갑옷입니다."),
            new Item("스파르타의 창", "공격력", +7, "스파르타의 전사들이 사용했다는 전설의 창입니다."),
            new Item("낡은 검", "공격력",+2, "쉽게 볼 수 있는 낡은 검 입니다.")
        };
    }

    public void ShowInventory() // 인벤토리 표시 
    {
        Console.Clear();
        Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n");
        Console.WriteLine("[아이템 목록]");
        for (int i = 0; i < Invenitems.Count; i++)
        {
            string equipped = Invenitems[i].IsEquip ? "[E]" : "";
            Console.WriteLine($"{i + 1}. {equipped}{Invenitems[i].Name} | {Invenitems[i].Type} |{Invenitems[i].Value} | {Invenitems[i].Description}");
        }
        Console.WriteLine("\n1. 장착 관리\n2. 나가기");
    }

    public void ManageEquipment() // 장착 관리
    {
        while (true)
        {
            ShowInventory();
            Console.Write("\n원하시는 아이템 번호를 입력해주세요 (0: 종료): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Invenitems.Count)
            {
                Invenitems[choice - 1].ToggleEquip();
                Console.WriteLine($"{Invenitems[choice - 1].Name} {(Invenitems[choice - 1].IsEquip ? "장착" : "해제")} 완료!");
            }
            else if (choice == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            Console.ReadKey();
        }
    }
}

public class Store
{
    private List<Item> storeitems; // 상점 아이템 목록
    private Player player; // 플레이어 참조
    public Store(Player player)
    {
        storeitems = new List<Item>() // 상점 아이템 목록  // 상점 초기화
        {
            new Item("수련자 갑옷", "방어력", +5, "수련에 도움을 주는 갑옷입니다.", 1000),
            new Item("무쇠갑옷", "방어력", +9, "무쇠로 만들어져 튼튼한 갑옷입니다.",0),
            new Item("스파르타의 갑옷", "방어력", +15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다",3500),
            new Item("낡은 검", "공격력", +2, "쉽게 볼 수 있는 낡은 검 입니다.",600),
            new Item("청동 도끼", "공격력", +5, "청동으로 만들어진 도끼입니다.",1500),
            new Item("스파르타의 창", "공격력", +7, "스파르타의 전사들이 사용했다는 전설의 창입니다.",0)
        };
        this.player = player;
    }

    public void ShowStore() // 상점 표시
    {
        Console.Clear();
        Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
        Console.WriteLine("[보유 골드]");
        Console.WriteLine($"Gold: {player.Gold}G\n");
        Console.WriteLine("[아이템 목록]");
        for (int i = 0; i < storeitems.Count; i++)
        {
            string priceText = storeitems[i].IsPurchased ? "구매완료" : $"{storeitems[i].Price}G";
            Console.WriteLine($"{i + 1}. {storeitems[i].Name} | {storeitems[i].Type} | {storeitems[i].Value} | {storeitems[i].Description} | {priceText}");
        }
        Console.WriteLine("\n1. 아이템 구매하기\n2. 나가기");
    }

    public void PurchaseItem() // 아이템 구매
    {
        while (true)
        {
            ShowStore();
            Console.Write("\n원하시는 아이템 번호를 입력해주세요 (0: 종료): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= storeitems.Count)
            {
                if (storeitems[choice - 1].Price <= 800)
                {
                    storeitems[choice - 1].TogglePurchase();
                    Console.WriteLine($"{storeitems[choice - 1].Name} 구매 완료!");
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
            }
            else if (choice == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            Console.ReadKey();
        }
    }

}


