using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iiPhoneFormat
{
    public partial class MainPage : ContentPage
    {
                

        public MainPage()
        {
            

            InitializeComponent();
        }

        /// <summary>
        /// Create a valid phone number with parenthesis around area code and a dash betweeen the exchange number and line number.
        /// </summary>
        /// <param name="str"></param>
        private void FormatNumber(ref string str)
        {
            str = str.Insert(0, "(");
            str = str.Insert(4, ")");
            str = str.Insert(8, "-");
        }

        /// <summary>
        /// Unformat a phone number if it is already formatted
        /// </summary>
        /// <param name="str"></param>
        private void UnformatTelephone(ref string str)
        {
            // Remove the characters (, ), and - from their repsective positions
            str = str.Remove(0, 1);
            str = str.Remove(3, 1);
            str = str.Remove(6, 1);
        }

        /// <summary>
        /// Validate input
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool ValidNumber(string str)
        {
            const int VALID_LENGTH = 10;

            // check string length
            if (str.Length == VALID_LENGTH)
            {
                // check each character to make sure it's a digit
                foreach(char ch in str)
                {
                    if(!char.IsDigit(ch))
                    {
                        // If a character is not a digit, return false
                        DisplayAlert("Invalid Character", "Please enter only numbers", "close");
                        return false;
                    }
                }

                // If we make it here, return true.
                return true;
            }
            else
            {
                DisplayAlert("Invalid Length", $"Number must be exactly {VALID_LENGTH} characters", "close");
                return false;
            }
        }


        /// <summary>
        /// Check for phone number validation and remove formatting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool ValidFormat(string str)        {
            
            const int VALID_LENGTH = 13;

            // Check if the phone number currently has formatting
            if (
                str.Length == VALID_LENGTH &&
                str[0] == '(' &&
                str[4] == ')' &&
                str[8] == '-'
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Unformat the number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void BtnUnFormat_Clicked(object sender, EventArgs e)
        {
            string str = PhoneEntry.Text.Trim();

            if(ValidFormat(str))
            {
                UnformatTelephone(ref str);
                LblResults.Text = str;
            }
            else
            {
                DisplayAlert("Invalid Input", "Telephone number not valid", "Close");
            }
        }

        /// <summary>
        ///   Format the number
        ///   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnFormat_Clicked(object sender, EventArgs e)
        {
            string str = PhoneEntry.Text.Trim();

            if (ValidNumber(str))
            {
                FormatNumber(ref str);
                LblResults.Text = str;
            }
            else
            {
                DisplayAlert("Invalid Input", "Number not correct format", "Close");
            }
        }
    }
}
