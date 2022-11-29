using System.Runtime.CompilerServices;

namespace Final_Project_Lesson_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    // Речь пойдет о доставке сырья добытого из нефтегазовых активов
    // Суть будет аналогичная магазину и доставке товаров
    abstract class Delivery
    {
        // Страна, в которую будет осуществляться доставка
        public string Country;

    }

    // Доставка по трубопроводам
    class TubeDelivery : Delivery
    {
        //Показать имя или номер трубопровода обобщенный метод
        public void Display<TName> (TName Name)
        {
            Console.WriteLine (Name.ToString);
        }
    }

    // Абсолютная Высота/Глубина расположения трубопровода по отношению к уровню моря
    // Метод расширения 
    // Если высота отрицательная - значит это глубина , но интересует только модуль числа - происходит получение положительного числа
    static class IntExtensions
    {
        public static int Absolute(this int MeasHeigth)
        {
            if (MeasHeigth < 0) { return -MeasHeigth; }
            else { return MeasHeigth; }
        }
    }

    // Доставка по Ж/Д путям
    //Обобщение
    class TrainDelivery<TIdTrain> : Delivery
    {
        public TIdTrain IdTrain;
    }

    // Доставка танкерами
    //Класс наследник с наследованием обобщений
    class TankerDelivery : TrainDelivery<string>
    {
        public string IdTanker { get; set; }
    }

    //Попытка применить агрегацию
    //Реализуется связь, при которой объекты тип танкера и танкер равноправны.
    public abstract class Type
    { 
    
    }
    public class GasTanker
    {
        Type type;
        //В конструктор газового танкера передается ссылка на объект Типа, который является абстрактным
        public GasTanker(Type tpe)
        {
            type = tpe;
        }
    }

    class Order<TDelivery,TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Country);
        }

        
    }

    //статический класс оплата контракта за сырье
    static class Cost_Product
    {
        static int Cost_Oil_Contract;
        static int Cost_Gas_Contract;

        static Cost_Product()
        {
            Console.WriteLine("Оплата за нефть: {0}, оплата за газ: {1}", Cost_Oil_Contract, Cost_Gas_Contract);
        }
    }

    //класс расстояние
    class Distance
    {
        //Расстояние внутри страны
        public int D_inside;
        //Расстояние вне страны
        public int D_outside;
        // Метод расчета суммарного расстояния
        public int Sum_Dist(ref int D_inside, ref int D_outside)
        {
            this.D_inside = D_inside;
            this.D_outside = D_outside;
            return D_inside + D_outside;
        }

        //Конструктор
        public Distance(int D_inside, int D_outside)
        {
            this.D_inside = D_inside;
            this.D_outside = D_outside;
        }
    }

    //абстрактный класс добытое сырье (нефть, газ)
    abstract class Product
    {
        //Страна экспортер открытая информация
        public string CountryExporter;
        //Защищенная информация - название актива, из которого добывается сырье
        private string Field;
        //Защищенная информация - объем нефти и газа в месторождении, понадобится в наследнике для расчета выработки
        protected int All_Oil_Volume;
        protected int All_Gas_Volume;
        //Переопределение метода - вызов сырья
        public virtual void Vol_Have()
        {
            Console.WriteLine("Доставка сырья");
        } 
    }

    //классы наследники нефть и газ
    class OilProduct : Product
    {
        public override void Vol_Have()
        {
            base.Vol_Have();
            Console.WriteLine("Cырье : нефть");
            Console.WriteLine("Всего хранится: {0}", All_Oil_Volume);
        }
        //Объем нефти транспортированный за день
        //Инкапсуляция
        //Свойства
        private int qday;
        public int Qday
        {
            get
            {
                if (qday <= 0)
                {
                    Console.WriteLine("Доставка отсутствует, либо неверные данные");
                    return 0;
                }
                else return qday;
            }
            set 
            {
                if (value < 0)
                {
                    Console.WriteLine("Объем должен быть положительным");
                }
                else qday = value;
            }
        }
    }

    class GasProduct : Product
    {
        public override void Vol_Have()
        {
            base.Vol_Have();
            Console.WriteLine("Cырье : газ");
            Console.WriteLine("Всего хранится: {0}", All_Gas_Volume);
        }
        

    }

        //Нахождение объема транспортировки газа по морю и суше
    //Применение перегруженных операторов
    class Gas_Transport
    {
        public int Value;
        public static Gas_Transport operator +(Gas_Transport Onshore, Gas_Transport Offshore)
        {
            return new Gas_Transport
            {
                Value = Onshore.Value + Offshore.Value,
            };
        }
    }
    //Теперь перегруженным оператором можно воспользоваться в любой части программы

    //Список стран импортеров
    //Применение индексаторов
    class Importers
    {
        public string Country;
    }

    class ImoprterList
    {
        //Хранение стран импортеров в виде массива
        private Importers[] list;
        //Конструктор с добавлением массива стран
        public ImoprterList (Importers[] list)
        {
            this.list = list;
        }

        //индексатор
        public Importers this[int index]
        {
            get
            {
                // Проверяем, чтобы индекс был в диапазоне для массива
                if (index >= 0 && index < list.Length)
                {
                    return list[index];
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                // Проверяем, чтобы индекс был в диапазоне для массива
                if (index >= 0 && index < list.Length)
                {
                    list[index] = value;
                }

            }
        }
}