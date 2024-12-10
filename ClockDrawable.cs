using Microsoft.Maui.Graphics;
using System;

namespace LLLAABA2.Pages.Controls
{
    public class ClockDrawable : IDrawable
    {
        public static ClockDrawable Instance { get; } = new ClockDrawable();

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var now = DateTime.UtcNow.AddHours(5); // Добавляем 5 часов к текущему времени
            float centerX = dirtyRect.Width / 2;
            float centerY = dirtyRect.Height / 2;
            float radius = Math.Min(dirtyRect.Width, dirtyRect.Height) / 2 * 0.9f;

            // Рисуем циферблат
            canvas.FillColor = Colors.White;
            canvas.FillCircle(centerX, centerY, radius);
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;

            // Деления
            for (int i = 0; i < 12; i++)
            {
                float angle = (float)(i * Math.PI / 6);
                float x1 = centerX + (float)(Math.Cos(angle) * radius);
                float y1 = centerY + (float)(Math.Sin(angle) * radius);
                float x2 = centerX + (float)(Math.Cos(angle) * (radius - 15));
                float y2 = centerY + (float)(Math.Sin(angle) * (radius - 15));
                canvas.DrawLine(x1, y1, x2, y2);
            }

            // Стрелки
            DrawHand(canvas, centerX, centerY, radius * 0.5f, now.Hour % 12 + now.Minute / 60f);
            DrawHand(canvas, centerX, centerY, radius * 0.75f, now.Minute / 5f + now.Second / 300f);
            DrawHand(canvas, centerX, centerY, radius * 0.9f, now.Second / 5f);
        }

        private void DrawHand(ICanvas canvas, float centerX, float centerY, float length, float position)
        {
            float angle = (float)(position * Math.PI / 6 - Math.PI / 2);
            float x = centerX + (float)(Math.Cos(angle) * length);
            float y = centerY + (float)(Math.Sin(angle) * length);
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 4;
            canvas.DrawLine(centerX, centerY, x, y);
        }
    }
}