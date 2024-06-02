using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace с1_FamilyTree
{
    internal static class FamilyTree
    {       
        public static void AddChild(Person parent, Person child)
        {
            if (parent != null && child != null)
            {
                parent.Children.Add(child);
                if (parent.Gender == Gender.Man)
                {
                    child.Father?.Children.Remove(child);
                    child.Father = parent;
                }
                else
                {
                    child.Mother?.Children.Remove(child);
                    child.Mother = parent;
                }
            }
            else
                Console.WriteLine("Пустые ссылки");
        }
        public static List<Person?> GetGrandPerents(Person person)
        {
            
            return new List<Person?>() { person?.Father?.Father, person?.Father?.Mother, person?.Mother?.Mother, person?.Mother?.Father };
        }
        public static void SetSpouses(Person spouses1, Person spouses2)
        {
            if(spouses1 != null && spouses2 != null)
            {
                spouses1.Spouse = spouses2;
                spouses2.Spouse = spouses1;
            }
        }
        public static void PrintTree(Person person)
        {
            string parents = string.Empty;
            string target = person.FullName;
            string siblings = string.Empty;
            string children = string.Empty;
            int interval = 0;
            string treeLine = "|";
            string ifSiblingsTreeLine = "/|";
            if (person.Father != null || person.Mother != null)
            {
                Person temp;
                if (person.Mother != null)
                {
                    temp = person.Mother;
                }
                else
                    temp = person.Father!;
                foreach (var sibling in temp.Children)
                {
                    if (sibling != person)
                    {
                        siblings += sibling.FullName + "   ";
                    }
                }
                target = siblings + target;
            }
            if(person.Spouse != null)
            {
                target = target + " --┬-- " + person.Spouse.FullName;
            }

            if (person.Father != null && person.Mother != null)
            {
                parents = person.Father.FullName + " --┬-- " + person.Mother.FullName;
                interval = parents.IndexOf('┬')+1;
                while(interval < target.IndexOf(person.FullName) + person.FullName.Length/2)
                {
                    parents = "   " + parents;
                    interval = parents.IndexOf('┬') + 1;
                }

            }
            else if(person.Father != null || person.Mother != null)
            {
                parents = person.Father?.FullName + person.Mother?.FullName;
                interval = parents.Length / 2;
                while (interval < target.IndexOf(person.FullName) + person.FullName.Length / 2)
                {
                    parents = "   " + parents;
                    interval += 3;
                }
            }
            while (interval > target.IndexOf(person.FullName) + person.FullName.Length / 2)
            {
                target = "   " + target;                
            }
            target = target.PadLeft(interval);
            treeLine = treeLine.PadLeft(interval);
            ifSiblingsTreeLine = ifSiblingsTreeLine.PadLeft(interval);
            
            if (!string.IsNullOrEmpty(parents))
            {
                Console.WriteLine(parents);
                Console.WriteLine(treeLine);
                if (!string.IsNullOrEmpty(siblings))
                    Console.WriteLine(ifSiblingsTreeLine);
                else Console.WriteLine(treeLine);
            }
            Console.WriteLine(target);

            if (person.Children.Count > 0)
            {
                foreach (var child in person.Children)
                {
                    children += child.FullName + "  ";
                }
                if (person.Spouse != null)
                {
                    interval = target.IndexOf('┬') + 1;
                }
                else
                {
                    interval = target.IndexOf(person.FullName) + person.FullName.Length / 2;
                }
                if(children.Length/2 < interval)
                {
                    children = new string(' ', interval - children.Length / 2) + children;
                }
                treeLine = treeLine.PadLeft(interval);
                ifSiblingsTreeLine = ifSiblingsTreeLine.PadLeft(interval);
                Console.WriteLine(treeLine);
                if(person.Children.Count > 1)
                    Console.WriteLine(ifSiblingsTreeLine);
                else Console.WriteLine(treeLine);
                Console.WriteLine(children);
            }     
        } 
    }
}
