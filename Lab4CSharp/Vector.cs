
using System;

class Vector
{
    protected int[] IntArray; // масив
    protected uint size; // розмір вектора
    protected int codeError; // код помилки
    protected static uint num_vec; // кількість векторів

    // Конструктори
    public Vector()
    {
        size = 1;
        IntArray = new int[size];
        codeError = 0;
        num_vec++;
    }

    public Vector(uint newSize)
    {
        size = newSize;
        IntArray = new int[size];
        codeError = 0;
        num_vec++;
    }

    public Vector(uint newSize, int initValue)
    {
        size = newSize;
        IntArray = new int[size];
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
        codeError = 0;
        num_vec++;
    }

    // Деструктор
    ~Vector()
    {
        Console.WriteLine("Vector object destroyed.");
    }

    // Методи
    public void InputElements()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            IntArray[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    public void DisplayElements()
    {
        Console.WriteLine("Vector elements:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Element {i + 1}: {IntArray[i]}");
        }
    }

    public void AssignValue(int value)
    {
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    // Статичний метод
    public static uint GetNumVec()
    {
        return num_vec;
    }

    // Властивості
    public uint Size
    {
        get { return size; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < size)
                return IntArray[index];
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            if (index >= 0 && index < size)
                IntArray[index] = value;
            else
                codeError = -1;
        }
    }

    // Перевантаження операторів

    // Унарні операції
    public static Vector operator ++(Vector vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i]++;
        }
        return vec;
    }

    public static Vector operator --(Vector vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i]--;
        }
        return vec;
    }

    public static bool operator true(Vector vec)
    {
        if (vec.size != 0)
        {
            foreach (int elem in vec.IntArray)
            {
                if (elem == 0)
                    return false;
            }
            return true;
        }
        else
            return false;
    }

    public static bool operator false(Vector vec)
    {
        if (vec.size == 0)
            return true;
        foreach (int elem in vec.IntArray)
        {
            if (elem != 0)
                return false;
        }
        return true;
    }

    public static bool operator !(Vector vec)
    {
        return vec.size != 0;
    }

    public static Vector operator ~(Vector vec)
    {
        Vector result = new Vector(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = ~vec.IntArray[i];
        }
        return result;
    }

    // Арифметичні бінарні операції
    public static Vector operator +(Vector vec1, Vector vec2)
    {
        uint maxSize = Math.Max(vec1.size, vec2.size);
        Vector result = new Vector(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            int val1 = i < vec1.size ? vec1.IntArray[i] : 0;
            int val2 = i < vec2.size ? vec2.IntArray[i] : 0;
            result.IntArray[i] = val1 + val2;
        }

        return result;
    }

    public static Vector operator +(Vector vec, int scalar)
    {
        Vector result = new Vector(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] + scalar;
        }
        return result;
    }

    // Інші бінарні операції

    // Метод тестування
    public static void Test()
    {
        // Створення векторів для тестування
        Vector vec1 = new Vector(3, 1);
        Vector vec2 = new Vector(3, 2);

        // Виведення векторів на екран
        Console.WriteLine("Vector 1:");
        vec1.DisplayElements();

        Console.WriteLine("\nVector 2:");
        vec2.DisplayElements();

        // Перевірка операцій
        Vector sum = vec1 + vec2;
        Console.WriteLine("\nVector 1 + Vector 2:");
        sum.DisplayElements();

        Vector sumScalar = vec1 + 5;
        Console.WriteLine("\nVector 1 + Scalar (5):");
        sumScalar.DisplayElements();

        Vector bitwiseComplement = ~vec1;
        Console.WriteLine("\nBitwise complement of Vector 1:");
        bitwiseComplement.DisplayElements();
    }
}

class Program1
{
    static void Main2(string[] args)
    {
        // Тестування класу Vector
        Vector.Test();
    }
}

