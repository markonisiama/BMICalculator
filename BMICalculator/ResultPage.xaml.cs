using System.Reflection;

namespace BMICalculator;

public partial class ResultPage : ContentPage
{
    double bmi;
    string category;
    Gender gender;

    public ResultPage(Gender gender, double height, double weight)
    {
        InitializeComponent();
        Title = "Results";

        this.gender = gender;
        // calculate BMI
        bmi = (weight / (height * height)) * 703;
        BmiValue.Text = $"BMI: {bmi:F1}";

        // determine category
        if (gender == Gender.Male)
        {
            if (bmi < 18.5) category = "Underweight";
            else if (bmi < 25) category = "Normal weight";
            else if (bmi < 30) category = "Overweight";
            else category = "Obese";
        }
        else
        {
            if (bmi < 18) category = "Underweight";
            else if (bmi < 24) category = "Normal weight";
            else if (bmi < 29) category = "Overweight";
            else category = "Obese";
        }

        Category.Text = category;
    }

    async void OnBackClicked(object s, EventArgs e)
        => await Navigation.PopAsync();

    async void OnRecsClicked(object s, EventArgs e)
        // pass gender + bmi + category on to Page 3
        => await Navigation.PushAsync(new RecommendationsPage(gender, bmi, category));
}