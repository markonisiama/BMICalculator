using System.Reflection;

namespace BMICalculator;

public partial class RecommendationsPage : ContentPage
{
    public RecommendationsPage(Gender gender, double bmi, string category)
    {
        InitializeComponent();
        Title = "Recommendations";

        // exact table text
        string[] recs = category switch
        {
            "Underweight" => new[]
            {
                "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains).",
                "Incorporate strength training to build muscle mass.",
                "Consult a nutritionist if needed."
            },
            "Normal weight" => new[]
            {
                "Maintain a balanced diet with proteins, healthy fats, and fiber.",
                "Stay physically active with at least 150 minutes of exercise per week.",
                "Keep regular check-ups to monitor overall health."
            },
            "Overweight" => new[]
            {
                "Reduce processed foods and focus on portion control.",
                "Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training.",
                "Drink plenty of water and track your progress."
            },
            _ => new[]
            {
                "Consult a doctor for personalized guidance.",
                "Start with low-impact exercises (e.g., walking, cycling).",
                "Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes.",
                "Avoid sugary drinks and maintain a consistent sleep schedule."
            }
        };

        foreach (var line in recs)
            RecList.Children.Add(new Label { Text = "• " + line, LineBreakMode = LineBreakMode.WordWrap });
    }

    async void OnBackClicked(object s, EventArgs e)
        => await Navigation.PopAsync();

    async void OnHomeClicked(object s, EventArgs e)
        => await Navigation.PopToRootAsync();
}