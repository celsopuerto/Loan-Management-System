using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Receipt : ContentPage
    {
        public Receipt()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            string status = $"{Application.Current.Properties["status"]}";
            int referenceNum = int.Parse($"{Application.Current.Properties["data"]}");

            var data = await App.db.GetAllAsync();

            if (data != null)
            {
                if (status == "add")
                {
                    var search = await App.db.SearchAsync(referenceNum);

                    if (search != null)
                    {
                        await DisplayAlert("Add Success", "Reference Number: " + referenceNum + "'s Data Added Successfully", "OK");

                        referenceNumberEntry.Text = search.ReferenceNumber.ToString();
                        nameEntry.Text = search.Name;
                        dateEntry.Text = search.Date;
                        typeEntry.Text = search.Type;
                        principalAmountEntry.Text = search.PrincipalAmount.ToString();
                        termsEntry.Text = search.Terms.ToString();
                        balanceEntry.Text = search.Balance.ToString();
                        serviceFeeEntry.Text = search.ServiceFee.ToString();
                        filingFeeEntry.Text = search.FilingFee.ToString();
                        insuranceFeeEntry.Text = search.InsuranceFee.ToString();
                        captialRetentionEntry.Text = search.CapitalRetention.ToString();
                        savingRetentionEntry.Text = search.SavingsRetention.ToString();
                        monthlyAmortizationEntry.Text = search.MonthlyAmortization.ToString();
                        principalMonthlyPayEntry.Text = search.PrincipalMonthlyPay.ToString();
                        interestMonthlyPayEntry.Text = search.InterestMonthlyPay.ToString();
                        netEntry.Text = search.Net.ToString();
                        totalInterestEarnedEntry.Text = search.TotalInterestEarned.ToString();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Reference Number: " + referenceNum + "'s Data Doesn't Exist!", "GO BACK");

                        await Navigation.PushAsync(new MainPage());
                    }
                }
                else if (status == "update")
                {
                    var search = await App.db.SearchAsync(referenceNum);

                    if (search != null)
                    {
                        await DisplayAlert("Update Success", "Reference Number: " + referenceNum + "'s Data Updated Successfully", "OK");

                        referenceNumberEntry.Text = search.ReferenceNumber.ToString();
                        nameEntry.Text = search.Name;
                        dateEntry.Text = search.Date;
                        typeEntry.Text = search.Type;
                        principalAmountEntry.Text = search.PrincipalAmount.ToString();
                        termsEntry.Text = search.Terms.ToString();
                        balanceEntry.Text = search.Balance.ToString();
                        serviceFeeEntry.Text = search.ServiceFee.ToString();
                        filingFeeEntry.Text = search.FilingFee.ToString();
                        insuranceFeeEntry.Text = search.InsuranceFee.ToString();
                        captialRetentionEntry.Text = search.CapitalRetention.ToString();
                        savingRetentionEntry.Text = search.SavingsRetention.ToString();
                        monthlyAmortizationEntry.Text = search.MonthlyAmortization.ToString();
                        principalMonthlyPayEntry.Text = search.PrincipalMonthlyPay.ToString();
                        interestMonthlyPayEntry.Text = search.InterestMonthlyPay.ToString();
                        netEntry.Text = search.Net.ToString();
                        totalInterestEarnedEntry.Text = search.TotalInterestEarned.ToString();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Reference Number: " + referenceNum + "'s Data Doesn't Exist!", "GO BACK");

                        await Navigation.PushAsync(new MainPage());
                    }
                }
                else if (status == "search")
                {
                    var search = await App.db.SearchAsync(referenceNum);

                    if(search != null)
                    {
                        await DisplayAlert("Search Success", "Reference Number: " + referenceNum + "'s Data Searched Successfully", "OK");

                        referenceNumberEntry.Text = search.ReferenceNumber.ToString();
                        nameEntry.Text = search.Name;
                        dateEntry.Text = search.Date;
                        typeEntry.Text = search.Type;
                        principalAmountEntry.Text = search.PrincipalAmount.ToString();
                        termsEntry.Text = search.Terms.ToString();
                        balanceEntry.Text = search.Balance.ToString();
                        serviceFeeEntry.Text = search.ServiceFee.ToString();
                        filingFeeEntry.Text = search.FilingFee.ToString();
                        insuranceFeeEntry.Text = search.InsuranceFee.ToString();
                        captialRetentionEntry.Text = search.CapitalRetention.ToString();
                        savingRetentionEntry.Text = search.SavingsRetention.ToString();
                        monthlyAmortizationEntry.Text = search.MonthlyAmortization.ToString();
                        principalMonthlyPayEntry.Text = search.PrincipalMonthlyPay.ToString();
                        interestMonthlyPayEntry.Text = search.InterestMonthlyPay.ToString();
                        netEntry.Text = search.Net.ToString();
                        totalInterestEarnedEntry.Text = search.TotalInterestEarned.ToString();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Reference Number: " + referenceNum + "'s Data Doesn't Exist!", "GO BACK");

                        await Navigation.PushAsync(new MainPage());
                    }
                }
            }
            else
            {
                await DisplayAlert("Notice!", "No Data Found!", "OK");
            }
        }
    }
}