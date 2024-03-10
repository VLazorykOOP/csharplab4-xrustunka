using System;

class MatrixInt
{
    protected int[,] IntArray; // масив
    protected int n, m; // розміри матриці
    protected int codeError; // код помилки
    protected static int num_vec; // кількість матриць

    // Конструктори
    public MatrixInt()
    {
        n = 1;
        m = 1;
        IntArray = new int[n, m];
        codeError = 0;
        num_vec++;
    }

    public MatrixInt(int n, int m)
    {
        this.n = n;
        this.m = m;
        IntArray = new int[n, m];
        codeError = 0;
        num_vec++;
    }

    public MatrixInt(int n, int m, int initValue)
    {
        this.n = n;
        this.m = m;
        IntArray = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = initValue;
            }
        }
        codeError = 0;
        num_vec++;
    }

    // Деструктор
    ~MatrixInt()
    {
        Console.WriteLine("Destructor called.");
    }

    // Методи
    public void InputElements()
    {
        Console.WriteLine("Enter elements of the matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("Enter element at position [{0},{1}]: ", i, j);
                IntArray[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void DisplayMatrix()
    {
        Console.WriteLine("Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(IntArray[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void SetAllElements(int value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = value;
            }
        }
    }

    public static int CountMatrices()
    {
        return num_vec;
    }

    // Властивості
    public int N
    {
        get { return n; }
    }

    public int M
    {
        get { return m; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатори
    public int this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return 0;
            }
            else
            {
                codeError = 0;
                return IntArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                IntArray[i, j] = value;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    public int this[int k]
    {
        get
        {
            if (k < 0 || k >= n * m)
            {
                codeError = -1;
                return 0;
            }
            else
            {
                codeError = 0;
                return IntArray[k / m, k % m];
            }
        }
    }

    // Перевантаження операторів

    // Унарні операції
    public static MatrixInt operator ++(MatrixInt matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.IntArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixInt operator --(MatrixInt matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.IntArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixInt matrix)
    {
        return matrix.n != 0 && matrix.m != 0 && !matrix.IsEmpty();
    }

    public static bool operator false(MatrixInt matrix)
    {
        return matrix.n == 0 || matrix.m == 0 || matrix.IsEmpty();
    }

    public bool IsEmpty()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (IntArray[i, j] != 0)
                    return false;
            }
        }
        return true;
    }

    public static bool operator !(MatrixInt matrix)
    {
        return matrix.n != 0 && matrix.m != 0;
    }

    public static MatrixInt operator ~(MatrixInt matrix)
    {
        MatrixInt result = new MatrixInt(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.IntArray[i, j] = ~matrix.IntArray[i, j];
            }
        }
        return result;
    }

    // Арифметичні операції
    public static MatrixInt operator +(MatrixInt matrix1, MatrixInt matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            Console.WriteLine("Matrix dimensions must be the same for addition operation.");
            return matrix1;
        }

        MatrixInt result = new MatrixInt(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result.IntArray[i, j] = matrix1.IntArray[i, j] + matrix2.IntArray[i, j];
            }
        }
        return result;
    }

    public static MatrixInt operator -(MatrixInt matrix1, MatrixInt matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            Console.WriteLine("Matrix dimensions must be the same for subtraction operation.");
            return matrix1;
        }

        MatrixInt result = new MatrixInt(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result.IntArray[i, j] = matrix1.IntArray[i, j] - matrix2.IntArray[i, j];
            }
        }
        return result;
    }

    public static MatrixInt operator *(MatrixInt matrix1, MatrixInt matrix2)
    {
        if (matrix1.m != matrix2.n)
        {
            Console.WriteLine("Number of columns of the first matrix must be equal to the number of rows of the second matrix for multiplication operation.");
            return new MatrixInt(); // Повертаємо пусту матрицю
        }

        MatrixInt result = new MatrixInt(matrix1.n, matrix2.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix2.m; j++)
            {
                int sum = 0;
                for (int k = 0; k < matrix1.m; k++)
                {
                    sum += matrix1.IntArray[i, k] * matrix2.IntArray[k, j];
                }
                result.IntArray[i, j] = sum;
            }
        }
        return result;
    }



    // Тестування класу
    public static void Test()
    {
        MatrixInt mat1 = new MatrixInt(2, 2);
        mat1.InputElements();
        mat1.DisplayMatrix();

        MatrixInt mat2 = new MatrixInt(2, 2);
        mat2.InputElements();
        mat2.DisplayMatrix();

        MatrixInt sum = mat1 + mat2;
        sum.DisplayMatrix();

    }
}

class Program
{
    static void Main(string[] args)
    {
        MatrixInt.Test();
    }
}
