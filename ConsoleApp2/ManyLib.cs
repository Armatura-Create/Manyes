using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    public class ManyLib
    {
        
        //Добавляет элемент к множеству
        public int[] Add(int[] many, int element)
        {
            var temp = new int[many.Length + 1];
            temp[temp.Length - 1] = element;
            for (var j = 0; j < many.Length; j++)
            {
                temp[j] = many[j];
            }

            return temp;
        }
        
        //Добавляет элемент к множеству по индексу
        public int[] Add(int[]many, int index, int element)
        {
            //Кидает исключение если индекс превышает размер множества+1
            if (index >= many.Length + 1)
            {
                throw new IndexOutOfRangeException();
            }
            
            var temp = new int[many.Length + 1];
            for (var j = 0; j < many.Length; j++)
            {
                if (j < element)
                {
                    temp[j] = many[j];
                } else if(index == j)
                    temp[j] = element;
                else 
                    temp[j] = many[j + 1];
            }

            return temp;
        }

        //Объединяет два множества
        public int[] Union(int[] many, int[] many2)
        {
            var temp = new int[0];
            foreach (var t in many)
            {
                temp = Add(temp, t);
            }
            
            foreach (var t in many2)
            {
                temp = Add(temp, t);
            }

            return temp;
        }

        //Удалят элемент множества по индексу
        public int[] RemoveIndex(int[] many, int index)
        {
            if (index >= many.Length)
            {
                throw new IndexOutOfRangeException();
            }

            var temp = new int[many.Length - 1];
            for (var j = 0; j < many.Length - 1; j++)
            {
                if (j < index)
                    temp[j] = many[j];
                else
                    temp[j] = many[j+1];
            }

            return temp;
        }
        
        //Удалят элемент множества по содержанию
        public int[] RemoveElement(int[] many, int element)
        {
            for (var j = 0; j < many.Length - 1; j++)
            {
                if (many[j] == element)
                    return RemoveIndex(many, j);
            }

            return many;
        }
        
        //Удаляем дубликаты в множестве
        public int[] RemoveDuplicate(int[] many)
        {
            int[] temp = new int[0];

            foreach (var i in many)
            {
                if (!ContainsElement(temp, i))
                {
                    temp = Add(temp, i);
                }
            }
            
            return temp;
        }

        //Пересечение множеств
        public int[] Intersect(int[] many, int [] many2)
        {
            var temp = new int[0];
            
            foreach (var i in many)
            {
                foreach (var t in many2)
                {
                    if (!ContainsElement(temp, t))
                    {
                        temp = Add(temp, t);
                    }
                    
                }
            }

            return temp;
        }

        //Разность множеств
        public int[] Except(int[] many, int[] many2)
        {
            int[] temp = many;

            foreach (var i in many)
            {
                foreach (var j in many2)
                {
                    if (i == j)
                    {
                        temp = RemoveElement(temp, i);
                    }
                }
            }
            
            return temp;
        }
        
        //Разность множеств
        public int[] SymExcept(int[] many, int[] many2)
        {
            return Except(Union(many, many2), Intersect(many, many2));
        }

        //Пренадлежность к множеству данного елемента
        public bool ContainsElement(int[] many, int element)
        {
            foreach (var t in many)
            {
                if (t == element)
                {
                    return true;
                }
            }

            return false;
        }
        
        //Сравнивает два множества и говорит равны ли они или нет
        public bool Contains(int[] many, int[] many2)
        {
            int i = 0;
            
            if (many.Length > many2.Length || many.Length < many2.Length)
            {
                return false;
            }
            
            foreach (var a in many)
            {
                foreach (var b in many2)
                {
                    if (a == b)
                    {
                        i++;
                    }
                }
            }

            return i == many.Length;
        }
        
        //Определяет пренадлежит ли первое множество второму
        public bool ContainsChild(int[] child, int[] parent)
        {

            if (child.Length > parent.Length)
            {
                return false;
            }
            
            int i = 0;
            
            foreach (var a in parent)
            {
                foreach (var b in parent)
                {
                    if (a == b)
                    {
                        i++;
                    }
                }
            }
            
            return i >= child.Length;
        }

        //Приводит множество в строку для вывода
        public string ToString(IEnumerable<int> many)
        {
            var result = many.Aggregate("[ ", (current, i) => current + (i + " "));
            result += "]";
            return result;
        }
    }
}