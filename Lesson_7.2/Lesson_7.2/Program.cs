using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Lesson_7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //    DerivedClass obj = new DerivedClass();
        //    obj.Display();
        //    var array = new Book[] {
        //    new Book { Name = "Мастер и Маргарита", Author = "М.А. Булгаков" },
        //    new Book { Name = "Отцы и дети", Author = "И.С. Тургенев" },
        //};
        //    BookCollection collection = new BookCollection(array);

        //    Console.ReadKey();

        //    Book book = collection[1];
        //    book = collection[-1];
        //    book = collection[4];

        //    Console.ReadKey();

        //    book = collection["Мастер и Маргарита"];

        //    int num1 = 3;
        //    int num2 = 58;

        //    Helper.Swap(ref num1, ref num2);

        //    Console.WriteLine(num1); //58
        //    Console.WriteLine(num2); //3

            int num1 = 7;
            int num2 = -13;
            int num3 = 0;

            Console.WriteLine(num1.GetNegative()); //-7
            Console.WriteLine(num1.GetPositive()); //7
            Console.WriteLine(num2.GetNegative()); //-13
            Console.WriteLine(num2.GetPositive()); //13
            Console.WriteLine(num3.GetNegative()); //0
            Console.WriteLine(num3.GetPositive()); //0
        }
    }

    //Задание 7.2.3 , Задание 7.2.5
    class BaseClass
    {
        public virtual void Display()
        {
            Console.WriteLine("метод класса baseclass");
        }
    }

    class DerivedClass : BaseClass
    {
        public override void Display()
        {
            base.Display();
            Console.WriteLine("метод класса DerivedClass");
        }
    }


    //Задание 7.2.4
    //class BaseClass
    //{
    //    public virtual int Counter
    //    {
    //        get;
    //        set;
    //    }
    //}

    //class DerivedClass : BaseClass
    //{
    //    public override int Counter
    //    {
    //        get { return Counter; }
    //        set
    //        {
    //            if (value < 0) { Console.WriteLine("Число должно быть положительным"); }
    //            else Counter = value;
    //        }
    //    }
    //}

    class A
    {
        public virtual void Display()
        {
            Console.WriteLine("A");
        }
    }

    class B : A
    {
        public new void Display()
        {
            Console.WriteLine("B");
        }
    }

    class C : A
    {
        public override void Display()
        {
            Console.WriteLine("C");
        }
    }

    class D : B
    {
        public new void Display()
        {
            Console.WriteLine("D");
        }
    }

    class E : C
    {
        public new void Display()
        {
            Console.WriteLine("E");
        }
    }

    //Задание 7.2.12
    //Для класса Obj перегрузите операторы + и -, чтобы результатом работы оператора был новый экземпляр класса Obj, а операции производились над полем Value.
    class Obj
    {
        public int Value;
        public static Obj operator + (Obj a, Obj b)
        {
            return new Obj { Value = a.Value + b.Value };
        }
        public static Obj operator - (Obj a, Obj b)
        {
            return new Obj { Value = a.Value - b.Value };
        }
    }

    //Индексация
    class Book
    {
        public string Name;
        public string Author;
    }

    class BookCollection
    {
        private Book[] collection;

        public BookCollection(Book[] collection)
        {
            this.collection = collection;
        }

        // Индексатор по массиву
        public Book this[int index]
        {
            get
            {
                // Проверяем, чтобы индекс был в диапазоне для массива
                if (index >= 0 && index < collection.Length)
                {
                    return collection[index];
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                // Проверяем, чтобы индекс был в диапазоне для массива
                if (index >= 0 && index < collection.Length)
                {
                    collection[index] = value;
                }
            }
        }

        public Book this[string name]
        {
            get
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    if (collection[i].Name == name)
                    {
                        return collection[i];
                    }
                }

                return null;
            }
        }
    }

    //Задание 7.2.14
    //Для следующего класса напишите индексатор, для типа параметра используйте int:
    class IndexingClass
    {
        private int[] array;

        public IndexingClass(int[] array)
        {
            this.array = array;
        }

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
    }

    //Задание 7.3.3
    //Создайте классы для следующих объектов компьютера: процессор(Processor), материнская карта(MotherBoard), видеокарта(GraphicCard). Унаследуйте их от класса ComputerPart.
    //Добавьте в класс ComputerPart абстрактный метод Work без параметров и с типом void.
    abstract class ComputerPart
    {
        public abstract void Work();
    }

    class Processor : ComputerPart
    {
        public override void Work() { }
    }

    class MotherBoard : ComputerPart
    {
        public override void Work() { }
    }

    class GraphicCard : ComputerPart
    {
        public override void Work() { }
    }

    //Задание 7.5.2
    //Создайте класс Obj, определите в нем поля Name, Description(тип строки) и статическое поле MaxValue типа int, равное 2000.
    class Obj2
    {
        public string Name;
        public string Description;
        public static int MaxValue = 2000;
    }

    //Задание 7.5.3
    //Создайте класс Helper и определите в нем статический метод Swap типа void, который принимает 2 переменные типа int и меняет их значения местами.
    class Helper
    {
        public static void Swap (ref int num1, ref int num2)
        {
            int k;
            k = num1;
            num1 = num2;
            num2 = k;
            
        }
    }

    //Задание 7.5.5
    //Измените класс Obj так, чтобы статические поля инициализировались в статическом конструкторе:
    class Obj3
    {
        public string Name;
        public string Description;

        public static string Parent = "System.Object";
        public static int DaysInWeek = 7;
        public static int MaxValue = 2000;

        static Obj3 ()
        {
            Parent = "System.Object";
            DaysInWeek = 7;
            MaxValue = 2000;
    }
    }

    //Задание 7.5.9
    //Для класса int создайте 2 метода расширения: GetNegative() и GetPositive().
    //Метод GetNegative должен возвращать отрицательное значение переменной(если оно положительно), либо саму переменную(если оно отрицательно или равно 0).
    //Метод GetPositive должен, наоборот, возвращать положительное значение(если оно отрицательно), либо саму переменную(если оно положительно или равно 0).

    static class IntExtensions
    {
        public static int GetNegative(this int num)
        {
            if (num > 0) { return -num; }
            else { return num; }
        }

        public static int GetPositive(this int num)
        {
            if (num < 0) { return -num; }
            else { return num; }
        }
    }
}