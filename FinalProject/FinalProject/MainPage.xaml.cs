using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            datePicker.Date = DateTime.Today;
        }

        void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            selectedDateLabel.Text = e.NewDate.ToString("MM/dd/yyyy");
        }

        void ResetForm()
        {
            referenceNumberEntry.Text = nameEntry.Text = principalAmountEntry.Text = termsEntry.Text
                        = balanceEntry.Text = selectedDateLabel.Text = string.Empty;
            typePicker.SelectedItem = null;
            datePicker.Date = DateTime.Today;
        }

        public async void AddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(referenceNumberEntry.Text) && !string.IsNullOrWhiteSpace(nameEntry.Text) && 
                !string.IsNullOrWhiteSpace(selectedDateLabel.Text) && !string.IsNullOrWhiteSpace(typePicker.SelectedItem.ToString()) && 
                !string.IsNullOrWhiteSpace(principalAmountEntry.Text) && !string.IsNullOrWhiteSpace(termsEntry.Text) && 
                !string.IsNullOrWhiteSpace(balanceEntry.Text))
            {

                try
                {
                    int refNum = int.Parse(referenceNumberEntry.Text);
                    string name = nameEntry.Text;
                    string date = selectedDateLabel.Text;
                    string type = typePicker.SelectedItem.ToString();
                    double principalAmount = double.Parse(principalAmountEntry.Text);
                    double terms = double.Parse(termsEntry.Text);
                    double balance = double.Parse(balanceEntry.Text);
                    double serviceFee = 0, filingFee = 0, insuranceFee, capitalRetention, savingRetention, monthlyAmortization, principalAmountMonthlyPay, interestMonthlyPay, net, totalInterestEarned;

                    // CALCULATIONS

                    if(principalAmount * 0.015 >= 1500)
                    {
                        serviceFee = 1500;
                    }
                    else
                    {
                        filingFee = 1500;
                    }

                    insuranceFee = principalAmount * 0.015 * terms / 12;

                    capitalRetention = principalAmount * 0.05;

                    savingRetention = principalAmount * 0.01;

                    monthlyAmortization = principalAmount * 0.015; //TEMP

                    principalAmountMonthlyPay = principalAmount / terms;

                    interestMonthlyPay = monthlyAmortization - principalAmountMonthlyPay;

                    net = principalAmount - (balance + serviceFee + filingFee 
                        + insuranceFee + capitalRetention + savingRetention);

                    totalInterestEarned = interestMonthlyPay - terms;

                    //DATABASE ACTION

                    table table = new table()
                    {
                        ReferenceNumber = refNum,
                        Name = name,
                        Date = date,
                        Type = type,
                        PrincipalAmount = principalAmount,
                        Terms = terms,
                        Balance = balance,
                        ServiceFee = serviceFee,
                        FilingFee = filingFee,
                        InsuranceFee = insuranceFee,
                        CapitalRetention = capitalRetention,
                        SavingsRetention = savingRetention,
                        MonthlyAmortization = monthlyAmortization,
                        PrincipalMonthlyPay = principalAmountMonthlyPay,
                        InterestMonthlyPay = interestMonthlyPay,
                        Net = net,
                        TotalInterestEarned = totalInterestEarned,
                    };
                    await App.db.SaveAsync(table);

                    ResetForm();

                    string status = "add";

                    Application.Current.Properties["status"] = status;
                    Application.Current.Properties["data"] = table.ReferenceNumber.ToString();
                    await Navigation.PushAsync(new Receipt());

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Admin", "Reference Number, Principal Amount, and Balance must be a Number!", "OK");
                }

            }
            else
            {
                await DisplayAlert("Admin", "Please fillup the form", "OK");
            }
        }

            public async void UpdateButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(referenceNumberEntry.Text) && !string.IsNullOrWhiteSpace(nameEntry.Text) &&
                !string.IsNullOrWhiteSpace(selectedDateLabel.Text) && !string.IsNullOrWhiteSpace(typePicker.SelectedItem.ToString()) &&
                !string.IsNullOrWhiteSpace(principalAmountEntry.Text) && !string.IsNullOrWhiteSpace(termsEntry.Text) &&
                !string.IsNullOrWhiteSpace(balanceEntry.Text))
            {

                try
                {
                    int refNum = int.Parse(referenceNumberEntry.Text);
                    string name = nameEntry.Text;
                    string date = selectedDateLabel.Text;
                    string type = typePicker.SelectedItem.ToString();
                    double principalAmount = double.Parse(principalAmountEntry.Text);
                    double terms = double.Parse(termsEntry.Text);
                    double balance = double.Parse(balanceEntry.Text);
                    double serviceFee = 0, filingFee = 0, insuranceFee, capitalRetention, savingRetention, monthlyAmortization, principalAmountMonthlyPay, interestMonthlyPay, net, totalInterestEarned;

                    // CALCULATIONS

                    if (principalAmount * 0.015 >= 1500)
                    {
                        serviceFee = 1500;
                    }
                    else
                    {
                        filingFee = 1500;
                    }

                    insuranceFee = principalAmount * 0.015 * terms / 12;

                    capitalRetention = principalAmount * 0.05;

                    savingRetention = principalAmount * 0.01;

                    monthlyAmortization = principalAmount * 0.015; //TEMP

                    principalAmountMonthlyPay = principalAmount / terms;

                    interestMonthlyPay = monthlyAmortization - principalAmountMonthlyPay;

                    net = principalAmount - (balance + serviceFee + filingFee
                        + insuranceFee + capitalRetention + savingRetention);

                    totalInterestEarned = interestMonthlyPay - terms;

                    //DATABASE ACTION

                    table table = new table()
                    {
                        ReferenceNumber = refNum,
                        Name = name,
                        Date = date,
                        Type = type,
                        PrincipalAmount = principalAmount,
                        Terms = terms,
                        Balance = balance,
                        ServiceFee = serviceFee,
                        FilingFee = filingFee,
                        InsuranceFee = insuranceFee,
                        CapitalRetention = capitalRetention,
                        SavingsRetention = savingRetention,
                        MonthlyAmortization = monthlyAmortization,
                        PrincipalMonthlyPay = principalAmountMonthlyPay,
                        InterestMonthlyPay = interestMonthlyPay,
                        Net = net,
                        TotalInterestEarned = totalInterestEarned,
                    };
                    await App.db.UpdateAsync(table);

                    ResetForm();

                    string status = "update";

                    Application.Current.Properties["status"] = status;
                    Application.Current.Properties["data"] = table.ReferenceNumber.ToString();
                    await Navigation.PushAsync(new Receipt());

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Admin", "Reference Number, Principal Amount, and Balance must be a Number!", "OK");
                }

            }
            else
            {
                await DisplayAlert("Admin", "Please fillup the form", "OK");
            }
        }

        public async void SearchButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(referenceNumberEntry.Text))
            {
                var table = await App.db.SearchAsync(int.Parse(referenceNumberEntry.Text));
                if (table != null)
                {
                    ResetForm();

                    string message = "---- Receipt ----" + "\nReference Number: " + table.ReferenceNumber + "\nName: " + table.Name
                        + "\nDate: " + table.Date + "\nType: " + table.Type + "\nPrincipal Amount: " + table.PrincipalAmount
                        + "\nTerms: " + table.Terms + "\nBalance: " + table.Balance + "\nService Fee: " + table.ServiceFee
                        + "\nFiling Fee: " + table.FilingFee + "\nInsurance Fee: " + table.InsuranceFee
                        + "\nCapital Retention: " + table.CapitalRetention + "\nSaving Retention: " + table.SavingsRetention
                        + "\nMonthly Amortization: " + table.MonthlyAmortization + "\nPrincipal (Monthly Pay): " + table.PrincipalMonthlyPay
                        + "\nInterest (Monthly Pay): " + table.InterestMonthlyPay + "\nNet: " + table.Net
                        + "\nTotal Interest Earned: " + table.TotalInterestEarned;

                    await DisplayAlert("Searched Info", message, "OK");
                }
                else
                {
                    await DisplayAlert("Admin", "Data doesn't exist", "OK");
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter Meter Number", "OK");
            }

        }

        public async void DeleteButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(referenceNumberEntry.Text))
            {
                var table = await App.db.SearchAsync(int.Parse(referenceNumberEntry.Text));
                if (table != null)
                {
                    int meter = int.Parse(referenceNumberEntry.Text);
                    var electricity = await App.db.SearchAsync(meter);

                    ResetForm();

                    string status = "delete";

                    if (electricity != null)
                    {
                        Application.Current.Properties["status"] = status;
                        Application.Current.Properties["data"] = electricity.ReferenceNumber.ToString();

                        await Navigation.PushAsync(new Receipt());
                    }
                    else
                    {
                        await DisplayAlert("Admin", "Data doesn't exist", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Admin", "Data doesn't exist", "OK");
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter Meter Number", "OK");
            }

        }
    }
}
