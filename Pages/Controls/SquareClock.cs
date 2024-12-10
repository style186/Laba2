using Microsoft.Maui.Controls;

namespace LLLAABA2.Models
{
    public class SquareClock : StackLayout
    {
        private Label[] squareLabels;

        public SquareClock()
        {
            squareLabels = new Label[6]; // 3 для часов, 2 для минут, 1 для секунд
            for (int i = 0; i < squareLabels.Length; i++)
            {
                squareLabels[i] = new Label
                {
                    WidthRequest = 50,
                    HeightRequest = 50,
                    BackgroundColor = Colors.Black,
                    TextColor = Colors.White,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    FontSize = 24
                };
                Children.Add(squareLabels[i]);
            }
        }

        public void UpdateTime(int hours, int minutes, int seconds)
        {
            squareLabels[0].Text = (hours / 10).ToString();
            squareLabels[1].Text = (hours % 10).ToString();
            squareLabels[2].Text = (minutes / 10).ToString();
            squareLabels[3].Text = (minutes % 10).ToString();
            squareLabels[4].Text = (seconds / 10).ToString();
            squareLabels[5].Text = (seconds % 10).ToString();
        }
    }
}