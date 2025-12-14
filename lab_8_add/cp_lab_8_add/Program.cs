// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace cp_lab_8_add_2
{
    public class MyBook : IComparable
{
    public int bookNomer { get; set; }
    public String Avtor { get; set; }
    public String Nazva { get; set; }
    public String Vydavnyctvo { get; set; }
    public Int16 RikVyhodu { get; set; }
    // Конструктор класу MyBook з параметрами для усiх полiв
    public MyBook(int bookNomer, String Avtor, String Nazva, String Vydavnyctvo, Int16 RikVyhodu)
    {
        this.bookNomer = bookNomer; this.Avtor = Avtor; this.Nazva = Nazva; this.Vydavnyctvo = Vydavnyctvo;
        this.RikVyhodu = RikVyhodu;
    }
    public override string ToString()
    {
        return "Книга №" + bookNomer.ToString() + " Автор: " + Avtor + " Назва: " + Nazva + " Видавництво: "
       + Vydavnyctvo + " Рiк: " + RikVyhodu.ToString();
    }
    // Реалізація методу CompareTo інтерфейсу IComparable.Параметр повинен бути типу object, тому необхідно
    // перевіряти сумісність типів.
    int IComparable.CompareTo(object? obj)
    {
        // приводимо параметр до типу MyBook
        if (obj is MyBook b) // якщо вдалось привести типи, то порiвнюємо поточний екземпляр з параметром
        {
            if (this.bookNomer == b.bookNomer) return 0;
            if (this.bookNomer > b.bookNomer) return 1;
            if (this.bookNomer < b.bookNomer) return -1;
            else return 0;
        }
        else // якщо не вдалось привести типи, то iнiцiалiзуємо переривання
            throw new ArgumentException("Параметр повинен бути типу MyBook");
    }
}

public class MyBooks : ArrayList, IEnumerable
{
    public MyBook[] MyBooksArray { get; set; }
    // Конструктор класу, якийстворює масив iз елементiв типу book кiлькiстю, яку задано у параметрi
    public MyBooks(int kilkistKnyh)
    {
        MyBooksArray = new MyBook[kilkistKnyh];
    }
}
public class BookNameComparer : IComparer
// Цей клас призначено для реалiзацiї порiвняння двох екземплярiв типу book по назвi (поле Nazva)
{
    // Реалiзацiя методу Compare iнтерфейсу IComparer 
    // Перевiряєм типи параметрiв, i якщо вони правильнi, то порiвнюємо назви книг
    int IComparer.Compare(object? o1, object? o2)
    {
        // Використаємо метод Compare для рядкоових змiнних. Цей метод поверне потрiбне цiле значення
        if (o1 is MyBook b1 && o2 is MyBook b2)
            return String.Compare(b1.Nazva, b2.Nazva);
        else
            throw new ArgumentException("Параметри не є класу MyBook");
    }
}
// Цей клас призначено для реалiзацiї порiвняння двох екземплярiв типу book по авторах (поле Nazva)
public class BookAvtorComparer : IComparer
{
    // Реалiзацiя методу Compare iнтерфейсу IComparer 
    // Перевiряємо типи параметрiв, i якщо вони правильнi, то порiвнюємо назви книг
    int IComparer.Compare(object? o1, object? o2)
    {
        // Використовуємо метод Compare для рядкових змiнних. Цей метод поверне потрiбне цiле значення
        if (o1 is MyBook b1 && o2 is MyBook b2)
            return String.Compare(b1.Avtor, b2.Avtor);
        else
            throw new ArgumentException("Параметри не є класу MyBook");
    }
}

class Program
{
    static void Main()
    {
        // Виведення непосортованого масиву
        Console.WriteLine("Виведення засобами класу MyBooks несортованого масиву");
        Console.WriteLine(); // Вiдступимо 1 рядок для оглядовостi

        // Додаємо книжки у масив MyBooksArray. Щоб працювали порiвняння компараторiв потрiбно щоб весь масив був заповнений
        MyBooks mbs1 = new MyBooks(5);
        mbs1.MyBooksArray[0] = new MyBook(7, "Ерiх Марiя Ремарк", "Три товаришi", "Ранок", 1981);
        mbs1.MyBooksArray[1] = new MyBook(9, "Всеволод Нестайко", "У країнi сонячних зайчикiв", "Ранок", 1961);
        mbs1.MyBooksArray[2] = new MyBook(2, "С.И.Баскаков", "Радиотехнические цепи и сигналы ", "М.: Высшая школа", 2000);
        mbs1.MyBooksArray[3] = new MyBook(5, "Джеймс Кервуд", "Грiзлi Казан ", "Київ, Молодь", 1962);
        mbs1.MyBooksArray[4] = new MyBook(4, "Ю.П.Пармузин", "Осторожно - пума", "Москва. Мисль", 1978);

        // Виводимо непосортований масив
        foreach (MyBook b in mbs1.MyBooksArray)
        {
            if (b != null) Console.WriteLine(b);
        }

        Console.WriteLine();

        // Сортування по номерах
        Array.Sort(mbs1.MyBooksArray);
        Console.WriteLine("Виведення засобами класу MyBooks масиву, який посортовано по полю Номер книги");
        Console.WriteLine();
        foreach (MyBook b in mbs1.MyBooksArray)
        {
            if (b != null) Console.WriteLine(b);
        }

        Console.WriteLine();

        // Сортування по назвах
        Array.Sort(mbs1.MyBooksArray, new BookNameComparer());
        Console.WriteLine("Виведення засобами класу MyBooks масиву, який посортовано по полю Назва книги");
        Console.WriteLine();
        foreach (MyBook b in mbs1.MyBooksArray)
        {
            if (b != null) Console.WriteLine(b);
        }

        Console.WriteLine();

        // Сортування по авторах
        Array.Sort(mbs1.MyBooksArray, new BookAvtorComparer());
        Console.WriteLine("Виведення засобами класу MyBooks масиву, який посортовано по полю Автор книги");
        Console.WriteLine();
        foreach (MyBook b in mbs1.MyBooksArray)
        {
            if (b != null) Console.WriteLine(b);
        }
    }
}
}