using System.Text;

namespace BMICalculator;
public enum Gender { None, Male, Female }

public partial class InputPage : ContentPage
{
    
    Gender selectedGender = Gender.None;

    public InputPage()
    {
        InitializeComponent();
        Title = "BMI Calculator";
        UpdateLabels();
    }

    void OnMaleTapped(object s, EventArgs e)
    {
        selectedGender = Gender.Male;
        MaleFrame.BorderColor = Colors.Blue;
        FemaleFrame.BorderColor = Colors.Transparent;
    }

    void OnFemaleTapped(object s, EventArgs e)
    {
        selectedGender = Gender.Female;
        FemaleFrame.BorderColor = Colors.Pink;
        MaleFrame.BorderColor = Colors.Transparent;
    }

    void OnSliderChanged(object s, ValueChangedEventArgs e)
        => UpdateLabels();

    void UpdateLabels()
    {
        HeightLabel.Text = $"{Math.Round(HeightSlider.Value)} in";
        WeightLabel.Text = $"{Math.Round(WeightSlider.Value)} lb";
    }

    async void OnNextClicked(object s, EventArgs e)
    {
        if (selectedGender == Gender.None || HeightSlider.Value == 0)
            return; // or alert user

        // Pass data into the ResultPage
        await Navigation.PushAsync(new ResultPage(
            selectedGender,
            Math.Round(HeightSlider.Value),
            Math.Round(WeightSlider.Value)
        ));
    }
}