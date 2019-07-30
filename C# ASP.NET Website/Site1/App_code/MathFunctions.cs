using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Useful functions. 
/// </summary>
namespace UtilityFunctions
{
    public static class MathFunctions
    {
        /// <summary>
        /// Sums all numbers counting from the first number to the second number. 
        /// </summary>
        /// <param name="intNumber1">Smaller numeber.</param>
        /// <param name="intNumber2">Larger number.</param>
        /// <param name="intStep">Increment rate.</param>
        /// <returns></returns>
        public static int SumInts( int intNumber1, int intNumber2, int intStep)
        {
            int intSum = 0;

            for (int intIndex = intNumber1; intIndex < intNumber2 + intStep; intIndex += intStep )
            {
                intSum += intIndex;
            }

            return intSum;
        }
        /// <summary>
        /// Sums all numbers counting from the first number to the second number. 
        /// </summary>
        /// <param name="dblNumber1">Smaller numeber.</param>
        /// <param name="dblNumber2">Larger number.</param>
        /// <param name="dblStep">Increment rate.</param>
        /// <returns></returns>
        public static double SumNumbers(double dblNumber1, double dblNumber2, double dblStep)
        {
            double dblSum = 0.0;

            for (double dblIndex = dblNumber1; dblIndex < dblNumber2 + dblStep; dblIndex += dblStep)
            {
                dblSum += dblIndex;
            }

            return dblSum;
        }
        /// <summary>
        /// Calculates the markup on an item. 
        /// </summary>
        /// <param name="sngBaseCost">The base cost of the item.</param>
        /// <param name="sngMarkupPercent">The markup percent.</param>
        /// <returns></returns>
        public static float CalculateMarkup( float sngBaseCost, float sngMarkupPercent )
        {
            float sngMarkup = 0.0f;

            sngMarkup = sngBaseCost + (sngBaseCost * sngMarkupPercent);

            return sngMarkup;
        }
        /// <summary>
        /// Calculates commission based on the number of items sold. 
        /// </summary>
        /// <param name="intItemsSold">Number of items sold.</param>
        /// <param name="intRetailPrice">The retail price of the item.</param>
        /// <returns>The commission earned.</returns>
        public static float CalculateCommission(int intItemsSold, int intRetailPrice)
        {
            float sngCommission = 0f;
            float sngPercentage = 0.0f;

            if (intItemsSold > 0 && intItemsSold < 10) sngPercentage = 0.05f;
            else if (intItemsSold >= 10 && intItemsSold < 100) sngPercentage = 0.1f;
            else if (intItemsSold >= 100) sngPercentage = 0.15f;

            sngCommission = intItemsSold * intRetailPrice * sngPercentage;

            return sngCommission;
        }
    }
}