using System;

namespace WSUniversalLib
{

    public class Calculation
    {


        public int GetQuantityForProduct(int productType, int materialType,
                                         int count, float width, float length)
        {
            // Проверка корректности входных данных
            if (count <= 0 || width <= 0 || length <= 0)
                return -1;

            if (float.IsNaN(width) || float.IsNaN(length) ||
                float.IsInfinity(width) || float.IsInfinity(length))
                return -1;

            // Коэффициенты типа продукции
            double productCoef;
            switch (productType)
            {
                case 1: productCoef = 1.1; break;
                case 2: productCoef = 2.5; break;
                case 3: productCoef = 8.43; break;
                default: return -1;
            }

            // Процент брака материала
            double defectPercent;
            switch (materialType)
            {
                case 1: defectPercent = 0.3; break; // 0.3%
                case 2: defectPercent = 0.12; break; // 0.12%
                default: return -1;
            }

            // Площадь одной единицы продукции
            double area = (double)width * length;

            // Количество качественного сырья на всю партию
            double cleanQuantity = area * productCoef * count;

            // Учёт брака
            double totalQuantity = cleanQuantity / (1.0 - defectPercent / 100.0);

            // Округление вверх до целого
            return (int)Math.Ceiling(totalQuantity);
        }
    }
}