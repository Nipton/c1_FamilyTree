namespace с1_FamilyTree
{
    internal class Program
    {
        static void Main()
        {
            //FamilyTree tree = new FamilyTree();

            Person GrandFatherOne = new("Иванов Иван Иванович", 50, Gender.Man);
            Person GrandMotherOne = new("Иванова Мария Дмитриевна", 60, Gender.Woman);

            Person GrandFatherSecond = new("Смирнов Петр Петрович", 51, Gender.Man);           
            Person GrandMotherSecond = new("Смирнова Екатрина Ивановна", 48, Gender.Woman);

            Person Father = new("Смирнов Кирилл Петрович", 35, Gender.Man);
            Person Mother = new("Смирнова Вера Ивановна", 30, Gender.Woman);
            Person Sister = new("Смирнова Елена Петровна", 36, Gender.Woman);
            Person Son = new("Смирнов Аркадий Кириллович", 16, Gender.Man);
            Person Daughter = new("Смирнова Анна Кирилловна", 15, Gender.Woman);


            FamilyTree.AddChild(GrandFatherOne, Mother);
            FamilyTree.AddChild(GrandMotherOne, Mother);

            FamilyTree.AddChild(GrandFatherSecond, Father);
            FamilyTree.AddChild(GrandMotherSecond, Father);

            FamilyTree.AddChild(GrandFatherSecond, Sister);
            FamilyTree.AddChild(GrandMotherSecond, Sister);

            FamilyTree.AddChild(Father, Son);
            FamilyTree.AddChild(Mother, Son);
            FamilyTree.AddChild(Father, Daughter);
            FamilyTree.AddChild(Mother, Daughter);

            FamilyTree.SetSpouses(Father, Mother);
            FamilyTree.SetSpouses(GrandFatherOne, GrandMotherOne);
            FamilyTree.SetSpouses(GrandFatherSecond, GrandMotherSecond);

            /*var gps = tree.GetGrandPerents(Daughter);
            foreach (var gp in gps)
            {
                if (gp != null)
                    Console.WriteLine(gp.FullName + " " + gp.Age);
            }*/

            FamilyTree.PrintTree(Father);
            
        }
    }
}