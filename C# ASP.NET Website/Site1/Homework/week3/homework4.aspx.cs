using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityFunctions;

public partial class Homework_week3_homework4 : System.Web.UI.Page
{
    protected void btnProblem1_Click(object sender, EventArgs e)
    {
        lblResult.Text = "The answer to Problem 1 is: " + Problem1() + ".";
    }
    protected void btnProblem2_Click(object sender, EventArgs e)
    {
        lblResult.Text = "The answer to Problem 2 is: " + Problem2() + ".";
    }
    protected void btnProblem3_Click(object sender, EventArgs e)
    {
        lblResult.Text = "The answer to Problem 3 is: " + Problem3() + "...I think.";
    }
    protected void btnProblem4_Click(object sender, EventArgs e)
    {
        lblResult.Text = "The answer to Problem 4 is: " + Problem4() + ".";
    }
    protected void btnProblem5_Click(object sender, EventArgs e)
    {
        lblResult.Text = "The answer to Problem 5 is: " + MakeFullName();
    }
    protected void btnProblem6_Click(object sender, EventArgs e)
    {
        lblResult.Text = "The answer to Problem 6 is: " + Problem6();
    }
    protected void btnProblem7_Click(object sender, EventArgs e)
    {
        lblResult.Text = "The answer to Problem 7 is: " + Problem7();
    }
    protected void btnProblem8_Click(object sender, EventArgs e)
    {
        lblResult.Text = "The answer to Problem 8 is " + Problem8() + ".";
    }
    /// <summary>
    /// Sums numbers 1 to 100. 
    /// </summary>
    /// <returns>Sum of numbers from 1 to 100.</returns>
    private int Problem1()
    {
        return MathFunctions.SumInts(1, 100, 1);
    }
    /// <summary>
    /// Sums numbers from -15 to 300
    /// </summary>
    /// <returns>Sum of numbers from -15 to 300.</returns>
    private int Problem2()
    {
        return MathFunctions.SumInts(-15, 300, 1);
    }
    /// <summary>
    /// Sums every 6.78/2.17 number from ( -212 / 7.304 ) to -690.3 and returns the result.
    /// </summary>
    /// <returns>The magic sum.</returns>
    private double Problem3()
    {
        double dblNumber1 = -690.3;
        double dblNumber2 = (-212 / 7.304);
        double dblStep = (6.78 / 2.17);

        return MathFunctions.SumNumbers(dblNumber1, dblNumber2, dblStep);
    }

    private string Problem4()
    {
        float sngInput1;
        float sngInput2;
        string strResult = "";

        if (float.TryParse(txtInput1.Text, out sngInput1)
            && float.TryParse(txtInput2.Text, out sngInput2))
        {
            strResult = MathFunctions.CalculateMarkup(sngInput1, sngInput2).ToString("c");
        }
        else 
        {
            strResult = "<p style='color:red'>Please fill in Input 1 and Input 2 with numbers.</p>";
        }

        return strResult;
    }
    /// <summary>
    /// Returns the full name with the following format: “Last, First”.
    /// </summary>
    /// <returns></returns>
    private string MakeFullName()
    {
        string strResult = "";

        if (string.IsNullOrWhiteSpace(txtInput1.Text)
            && string.IsNullOrWhiteSpace(txtInput2.Text))
        {
            strResult = "<p style='color:red'>Please fill in Input 1 and Input 2 with first and last name.</p>";    
        }
        else { strResult = txtInput2.Text + ", " + txtInput1.Text; }

        return strResult;
    }

    /// <summary>
    /// Calculates a commission from user input.
    /// </summary>
    /// <returns>The commission calcualtedl.</returns>
    private string Problem6()
    {
        int intItemsSold = 0;
        int intRetailPrice = 0;
        string strResult = "";

        if (int.TryParse(txtInput1.Text, out intItemsSold)
          && int.TryParse(txtInput2.Text, out intRetailPrice))
        {
            strResult = MathFunctions.CalculateCommission(intItemsSold, intRetailPrice).ToString("c");
        }
        else { strResult = "<p style='color:red'>Please fill in Input 1 with number of items sold and Input 2 with whole number retail price.</p>"; }

        return strResult;
    }
    /// <summary>
    /// A game where user guesses a number between 1 and 10. 
    /// </summary>
    /// <param name="intGuess">The user's guess.</param>
    /// <returns>The answer or a hint.</returns>
    private string Problem7( )
    {
        int intGuess = 0;
        string strResult = "";

        if( int.TryParse(txtInput1.Text, out intGuess ) 
            && intGuess <= 10 && intGuess >= 1 )
        {
                if (intGuess > 4) { strResult = "Number too high!"; }
                else if( intGuess < 4)  { strResult = "Number too low!"; }
                else{ strResult = "You guessed it!";}
        }
        else { strResult = "<p style='color:red'>Please enter a whole number between 1 and 10 in Input 1!</p>"; }
        
        return strResult;
    }
    /// <summary>
    /// Performs an artimetic operation on the input number.
    /// </summary>
    /// <param name="dblNumber"></param>
    /// <returns></returns>
    private string Problem8( )
    {
        double dblNumber = 0D;
        double dblResult = 0D;
        string strResult = "";

        if (double.TryParse(txtInput1.Text, out dblNumber))
        {
            dblResult = Math.Pow(dblNumber, 3D);
            dblResult *= 3;
            dblResult /= 4;
            strResult = dblResult.ToString();
        }
        else { strResult = "<p style='color:red'>Please enter a number in Input 1.</p>"; }

        return strResult;
    }
}