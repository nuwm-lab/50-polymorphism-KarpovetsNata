using System;
namespace TriangleApp
{
    // ===== БАЗОВИЙ КЛАС =====
    class EquilateralTriangle
    {
        public double side; // довжина сторони
        public double angle; // кут між сторонами (у градусах)
        public double perimeter;


        // --- віртуальний метод для ініціалізації ---
        public virtual void Init()
        {
            Console.Write("Введіть довжину сторони рівностороннього трикутника: ");
            side = Convert.ToDouble(Console.ReadLine());
            angle = 60; // усі кути по 60 градусів
        }


        // --- віртуальний метод для виведення ---
        public virtual void Show()
        {
            Console.WriteLine("Рівносторонній трикутник:");
            Console.WriteLine($"Сторона = {side}");
            Console.WriteLine($"Кути: {angle}, {angle}, {angle}");
        }


        // --- віртуальний метод для обчислення периметра ---
        public virtual double Perimeter()
        {
            perimeter = 3 * side;
            Console.WriteLine($"Периметр = {perimeter}");
            return perimeter;
        }
    }


    // ===== ПОХІДНИЙ КЛАС =====
    class Triangle : EquilateralTriangle
    {
        public double sideA, angleB, angleC; // задані сторона і кути


        // --- перевизначення ініціалізації ---
        public override void Init()
        {
            Console.Write("Введіть довжину сторони a: ");
            sideA = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть значення кута B (в градусах): ");
            angleB = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть значення кута C (в градусах): ");
            angleC = Convert.ToDouble(Console.ReadLine());
        }


        // --- перевизначення відображення ---
        public override void Show()
        {
            double angleA = 180 - (angleB + angleC);
            Console.WriteLine("Звичайний трикутник:");
            Console.WriteLine($"Сторона a = {sideA}");
            Console.WriteLine($"Кути: A = {angleA}, B = {angleB}, C = {angleC}");
        }


        // --- перевизначення обчислення периметра ---
        public override double Perimeter()
        {
            // за законом синусів: a / sinA = b / sinB = c / sinC
            double angleA = 180 - (angleB + angleC);
            double radA = angleA * Math.PI / 180;
            double radB = angleB * Math.PI / 180;
            double radC = angleC * Math.PI / 180;


            double b = sideA * Math.Sin(radB) / Math.Sin(radA);
            double c = sideA * Math.Sin(radC) / Math.Sin(radA);


            perimeter = sideA + b + c;
            Console.WriteLine($"Периметр = {perimeter:F2}");
            return perimeter;
        }
    }


    // ===== ПРОГРАМА =====
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice;
            EquilateralTriangle baseTriangle;


            do
            {
                Console.WriteLine("\nОберіть тип трикутника:");
                Console.WriteLine("0 - Рівносторонній трикутник");
                Console.WriteLine("1 - Звичайний трикутник (задана сторона і два кути)");
                Console.WriteLine("Інше - вихід");
                Console.Write("Ваш вибір: ");
                userChoice = Convert.ToInt32(Console.ReadLine());


                if (userChoice == 0)
                    baseTriangle = new EquilateralTriangle();
                else if (userChoice == 1)
                    baseTriangle = new Triangle();
                else
                    return;


                // робота через покажчик на базовий клас
                baseTriangle.Init();
                baseTriangle.Show();
                baseTriangle.Perimeter();


            } while (true);
        }
    }
}

