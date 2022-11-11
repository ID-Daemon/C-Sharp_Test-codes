// Задаем размерность матрицы
int rows = 5, cols = 5;
int[,] spiral = new int[cols, rows];
int[] countStep = { 1, (cols * rows) };
                // Текущий шаг, Максимальное кол-во шагов
// X - столбцы (rows), Y - строки (cols)
int x = 0, y = 0, route = 0;
StepsInSpiral(x, y, route);
ViewDablArray(spiral);
 // Метод для заполнения матрицы по спирали
void StepsInSpiral(int x, int y, int route) {
    int step = countStep[0];
    if (step <= countStep[1]) {
        if (CanStep(step, x, y)) {
            spiral[y, x] = step;
            countStep[0]++;
            switch (route) {
            // 0 - вправо | 1 - вниз | 2 - влево | 3 - вверх
                case 2: StepsInSpiral(x - 1, y, route); break;
                case 3: StepsInSpiral(x, y - 1, route); break;
                case 0: StepsInSpiral(x + 1, y, route); break;
                case 1: StepsInSpiral(x, y + 1, route); break;
            }
        }
        else {
            switch (route) {
                case 2: x += 1; break;
                case 3: y += 1; break;
                case 0: x -= 1; break;
                case 1: y -= 1; break;
            }
            route = ChangeRout(route);
            countStep[0]--;
            spiral[y, x] = 0;
            StepsInSpiral(x, y, route);
        }
    }
}
// Проверка возможности хода
bool CanStep(int step, int x, int y) {
    bool[] parametrs = {
        (x < spiral.GetLength(1)),
        (x >= 0),                 // Проверяем не вышли ли за границы координат X
        (y < spiral.GetLength(0)),
        (y >= 0)                 // Проверяем не вышли ли за границы координат y
    };
    return parametrs[0] && parametrs[2] && parametrs[1] && parametrs[3] && (spiral[y, x] == 0);;
}                                                                          // Проверяем пустая ли ячейка, в которую мы хотим записать наш шаг
// Смена направление
int ChangeRout(int route) {
    route++; route %= 4;
    return route;
}
// Корректый показ двумерного массива целочисленных цифр
void ViewDablArray(int[,] collection) {
    int lengthNumber = (collection.GetLength(0) * collection.GetLength(1)).ToString().Length;
    for (int i = 0; i < collection.GetLength(0); i++)
    {
        for (int j = 0; j < collection.GetLength(1); j++)
        {
            for (int y = 0; y < lengthNumber - collection[i, j].ToString()!.Length; y++) Console.Write(" ");
            Console.Write($"{collection[i, j]} ");
        }
        Console.WriteLine();
    }
}