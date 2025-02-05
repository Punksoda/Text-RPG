public class Player // 플레이어 클래스 생성, 해당 클래스 파일에서는 플레이어의 기본적인 정보와, 플레이어가 호출되어 상태가 변경될때 쓰이는 함수들이 정의되어 있습니다.
{
    public int Lv { get; set; } // 플레이어 클래스의 필드 생성
    public string Name { get; set; }
    public string Job { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Gold { get; set; }

    private List<Item> equipItems; // 장착한 아이템 목록

    public Player(string name, string job, int atk, int def, int hp, int gold) // 새로운 플레이어를 생성해서 초기화 해줌
    {
        Lv = 1;
        Name = name;
        Job = job;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
        equipItems = new List<Item>();
    }


    /*public void InputStatus() 직접 입력받는 방식으로 해보고 싶었으나, 잘 되지 않아 주석처리했습니다! 값을 변환하는 방식도 문제가 있다고 생각합니다
    {
        Console.WriteLine("캐릭터의 레벨, 이름, 직업, 공격력, 방어력, 체력, 초기 소지 골드양을 입력합니다!\n");
   
        Console.Write("Lv: ");
        int Lv = int.Parse(Console.ReadLine());
        Console.Write("Name");
        Name = Console.ReadLine();
        Console.Write("Class: ");
        Class = Console.ReadLine();
        Console.Write("ATK: ");
        Atk = int.Parse(Console.ReadLine());
        Console.Write("DEF: ");
        Def = int.Parse(Console.ReadLine());
        Console.Write("HP: ");
        Hp = int.Parse(Console.ReadLine());
        Console.Write("Gold: ");
        Gold = int.Parse(Console.ReadLine());
    }*/

    public void ShowStatus() // program.cs에서 호출되어 실행되는 함수로, 캐릭터의 정보를 표시해줍니다.
    {
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");

        Console.WriteLine("\n====================");
        Console.WriteLine($"Lv. {Lv}");
        Console.WriteLine($"{Name}, {Job}");
        Console.WriteLine($"공격력 : {Atk}");
        Console.WriteLine($"방어력 : {Def}");
        Console.WriteLine($"체 력 : {Hp}");
        Console.WriteLine($"Gold : {Gold}G");
        Console.WriteLine("====================\n");
        Console.WriteLine("0. 나가기\n");

        Console.Write("원하시는 행동을 입력해주세요.\n>> ");
        Console.ReadLine();

    }

    public bool SpendGold(int amount) // 골드를 사용하는 함수로, 골드가 부족하면 false를 반환합니다, 하지만 실제 상점 구현에서 문제가 발생했습니다...
    {
        if (Gold >= amount)
        {
            Gold -= amount;
            return true;
        }
        else
        {
            Console.WriteLine("골드가 부족합니다.");
            return false;
        }
    }

    public void EquipItem(Item item) // 플레이어가 아이템을 장착하는 함수입니다!
    {
        if (item.IsEquip)
        {
            // 이미 장착된 아이템이라면 해제
            if (item.Type == "공격력")
                Atk -= item.Value;
            else if (item.Type == "방어력")
                Def -= item.Value;

            equipItems.Remove(item);
            item.ToggleEquip();
            Console.WriteLine($"{item.Name} 해제 완료!");
        }
        else
        {
            // 새로 장착
            if (item.Type == "공격력")
                Atk += item.Value;
            else if (item.Type == "방어력")
                Def += item.Value;

            equipItems.Add(item);
            item.ToggleEquip();
            Console.WriteLine($"{item.Name} 장착 완료!");
        }
    }
}
