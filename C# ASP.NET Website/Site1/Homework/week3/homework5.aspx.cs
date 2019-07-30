using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Homework_week3_homework5 : System.Web.UI.Page
{
    protected void btnCountVowels_Click(object sender, EventArgs e)
    {
        string strMessage = "";

        if (!string.IsNullOrWhiteSpace(txtSentence.Text))
        {
            strMessage = "Vowels: " + CountVowels(txtSentence.Text);
        }
        else 
        { 
            strMessage = "Please enter a sentence."; 
        }

        ShowMessage(strMessage);
    }
    protected void btnCountWords_Click(object sender, EventArgs e)
    {
        string strMessage = "";

        if (!string.IsNullOrWhiteSpace(txtSentence.Text))
        {
            strMessage = "Words: " + CountWords(txtSentence.Text);
        }
        else
        {
            strMessage = "Please enter a sentence.";
        }

        ShowMessage(strMessage);
    }
    protected void btnReverse_Click(object sender, EventArgs e)
    {
        string strMessage = "";

        if (!string.IsNullOrWhiteSpace(txtSentence.Text))
        {
            txtSentence.Text = ReverseString(txtSentence.Text);
        }
        else
        {
            strMessage = "Please enter a sentence.";
            ShowMessage(strMessage);
        }
    }
    protected void btnBreakApart_Click(object sender, EventArgs e)
    {
        BreakApartRecords(txtRecord.Text);
    }
    protected void btnPutTogether_Click(object sender, EventArgs e)
    {
        PutFieldsTogether();
    }
    protected void btnFormatNumber_Click(object sender, EventArgs e)
    {
        long lngOutput = 0;
        txtFormattedNumber.Text = "";

        if ( txtPhoneNumber.Text.Length == 10
            && long.TryParse(txtPhoneNumber.Text, out lngOutput))
        {
            txtFormattedNumber.Text = FormatPhoneNumber(txtPhoneNumber.Text);
        }
        else { ShowMessage("Please enter an unformatted 10 digit phone number."); }
    }

        /// <summary>
        /// Displays a javaScript alert with a message.
        /// </summary>
        /// <param name="strMessage">Message to be displayed.</param>
        private void ShowMessage(string strMessage)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + strMessage + "');", true);
        }

    

    /// <summary>
    /// Counts the number of vowels (a, e, i, o, u) in a string. 
    /// </summary>
    /// <param name="strInput">String to count vowels from.</param>
    /// <returns>The vowel count.</returns>
    private int CountVowels(string strInput)
    {
        int intCount = 0;

        foreach (char chrLetter in strInput) 
        {
            if (chrLetter == 'a' || chrLetter == 'e' || chrLetter == 'i' || chrLetter == 'o' || chrLetter == 'u')
            {
                intCount += 1;
            }
        }
        
        return intCount;
    }

    /// <summary>
    /// Counts the number of words in a string. 
    /// </summary>
    /// <param name="strInput">String to count words from.</param>
    /// <returns>The word count.</returns>
    private int CountWords(string strInput)
    {
        int intCount = 0;
        strInput = strInput.Trim();

        for (int intIndex = 0; intIndex < strInput.Length; intIndex++)
        {   
            if( IsEndOfWord(strInput[intIndex]) )
            {
                // Check that previous character was not punctuation 
                if (intIndex > 0)
                {
                    if( !IsEndOfWord( strInput[intIndex - 1] ) )
                    {
                        intCount ++;
                    }
                }
            } 
        }

        return intCount;
    }
        /// <summary>
        /// Checks whether the letter marks the end of a word ([space], [.], [,], [!], [?])
        /// </summary>
        /// <param name="chrLetter">Letter to test.</param>
        /// <returns></returns>
        private bool IsEndOfWord(char chrLetter)
        {
            bool blnIsEnd = false;

            if (chrLetter == ' ' || chrLetter == '.' || chrLetter == ',' || chrLetter == '!' || chrLetter == '?')
            { 
                blnIsEnd = true; 
            }

            return blnIsEnd;
        }

    /// <summary>
    /// Reverses a string. 
    /// </summary>
    /// <param name="strString">String to be reversed.</param>
    /// <returns>Reversed string.</returns>
    private string ReverseString(string strString)
    {
        System.Text.StringBuilder stbReverse = new System.Text.StringBuilder();

        for (int intIndex = strString.Length - 1; intIndex >= 0; intIndex-- )
        {
            stbReverse.Append(strString[intIndex]);
        }

        return stbReverse.ToString();
    }

    /// <summary>
    /// Splits a record by comma-separated fields. Handles up to 6 records. 
    /// </summary>
    /// <param name="strRecords">The record to be split.</param>
    private void BreakApartRecords(string strRecords)
    {
        string[] astrRecords = strRecords.Split(new char[] {','} );
        TextBox[] atxtFields = new TextBox[] { txtField1, txtField2, txtField3, txtField4, txtField5, txtField6 };

        // Clear text boxes
        txtRecord.Text = "";
        ClearFields();

        // Fill in each field
        for( int intIndex = 0; intIndex < astrRecords.Length && intIndex < 6; intIndex ++ )
        {
            atxtFields[intIndex].Text = astrRecords[intIndex].Trim();
        }
    }

    /// <summary>
    /// Combines fields into one record. 
    /// </summary>
    private void PutFieldsTogether()
    {
        TextBox[] atxtFields = new TextBox[] { txtField1, txtField2, txtField3, txtField4, txtField5, txtField6 };
        string strRecord = "";

        // Fill in each field
        for (int intIndex = 0; intIndex < 6; intIndex++)
        {
            strRecord += atxtFields[intIndex].Text;

            if (intIndex < 5) { strRecord += ", ";}
        }

        // Clear field text boxes
        ClearFields();

        txtRecord.Text = strRecord;
    }

        /// <summary>
        /// Clears the txtField# textboxes.
        /// </summary>
        private void ClearFields()
        {
            TextBox[] atxtFields = new TextBox[] { txtField1, txtField2, txtField3, txtField4, txtField5, txtField6 };

            foreach (TextBox txtTextBox in atxtFields) { txtTextBox.Text = ""; }
        }

    /// <summary>
    /// Formats a 10 digit phone number.
    /// </summary>
    /// <param name="strUnformattedNumber"></param>
    /// <returns>A formatted phone number (###)-###-####.</returns>
    private string FormatPhoneNumber(string strUnformattedNumber)
    {
        return Regex.Replace(strUnformattedNumber, @"(\d{3})(\d{3})(\d{4})", @"($1)-$2-$3");
    }
}