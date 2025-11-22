using System;

namespace cp_lab_11
{
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        // поле для перевірки, чи автомобіль не зламався 
        private bool carIsDead;

        // додане статичне поле (сукупний пройдений шлях у годинах * швидкість переведена в кілометри)
        public static double distance = 0;

        // Оголошення делегата у класі Car 
        public delegate void CarEngineHandler(string msgForCaller);

        // Оголошення закритої змінної listOfHandlers типу делегат 
        private CarEngineHandler listOfHandlers;

        // Конструктор класу (за замовчуванням)
        public Car()
        {
            MaxSpeed = 100;
        }

        // Конструктор з параметрами 
        public Car(string name, int maxSp, int currSp)
        {
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
            PetName = name;
            carIsDead = false;
        }

        // Додавання методу для доступу до змінної listOfHandlers ззовні 
        public void RegisterWithCarEngine(CarEngineHandler metodToCall)
        {
            // Змінний оператор += дозволяє додавати кілька підписок
            listOfHandlers += metodToCall;
        }

        /* Метод для зміни поточної швидкості автомобіля. Він буде викликати процес 
         * створення повідомлення і додавання його до тексту мітки. 
         * Залежно від швидкості автомобіля, будуть генеруватись різні повідомлення */
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                // Якщо автомобіль вже зламався, повідомляємо підписників (якщо такі є)
                if (listOfHandlers != null)
                    listOfHandlers("На жаль, автомобіль зламався");
            }
            else
            {
                // до шляху пробігу додаємо шлях пробігу за 10 хвилин.
                // 0.16 години це приблизно 10 хвилин
                distance += CurrentSpeed * 0.16;

                CurrentSpeed += delta;

                // Перевіряємо, чи передано метод у змінну listOfHandlers, а також
                // перевіряємо, чи не занадто велика швидкість і якщо так, то видаємо повідомлення
                if ((MaxSpeed - CurrentSpeed <= 10) && (CurrentSpeed < MaxSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Увага! Занадто велика швидкість!");
                }
                else
                {
                    if (CurrentSpeed >= MaxSpeed)
                        carIsDead = true;
                    else
                    {
                        if (listOfHandlers != null)
                            listOfHandlers("Поточна швидкість=" + CurrentSpeed.ToString());
                    }
                }
            }
        }
    }
}
