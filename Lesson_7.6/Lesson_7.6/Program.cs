namespace Lesson_7._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    //Задание 7.6.2
    //Создайте класс-обобщение Car для автомобиля.Универсальным параметром будет тип двигателя в автомобиле (электрический и бензиновый). 
    //Для типов двигателей также создайте классы — ElectricEngine и GasEngine.
    //В классе Car создайте поле Engine в качестве типа которому укажите универсальный параметр.
    //Задание 7.6.7
    //Добавьте к схеме классов автомобиля следующие классы частей автомобиля: Battery, Differential, Wheel.
    //Также добавьте в класс Car виртуальный обобщённый метод без реализации — ChangePart, который будет принимать один параметр — newPart универсального типа.
    class Car<T1> where T1 : Engine
    {
        public T1 Engine;
        public virtual void ChangePart<T2>(T2 newPart) where T2 : CarPart
        {

        }
    }

    class ElectricEngine : Engine { }
    class GasEngine : Engine { }
    class Battery : CarPart { }
    class Differential : CarPart { }
    class Wheel : CarPart { }
    class Engine { }
    class CarPart { }

    class ElectricCar : Car<ElectricEngine>
    {
        public override void ChangePart<TPart>(TPart newPart)
        {

        }
    }

    //Задание 7.6.6
    //Реализуйте класс-обобщение Record, у которого будут два универсальных параметра: один — для идентификатора записи(Id), другой — для значения записи(Value). 
    //Также в классе реализуйте поле Date типа DateTime.
    class Record<T1, T2>
    {
        public T1 Id;
        public T2 Value;
        public DateTime Date;
    }

    

    


}