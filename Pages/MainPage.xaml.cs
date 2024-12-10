using System;
using System.Timers; // Используем System.Timers.Timer
using Microsoft.Maui.Controls;

namespace LLLAABA2.Pages
{
    public partial class MainPage : ContentPage
    {
        private System.Timers.Timer? timer; // Объявляем таймер как nullable

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += OnLoaded; // Подписываемся на событие загрузки
            this.Unloaded += OnUnloaded; // Подписываемся на событие выгрузки
        }

        private void OnLoaded(object? sender, EventArgs e)
        {
            // Инициализация таймера
            timer = new System.Timers.Timer(1000); // Устанавливаем интервал в 1 секунду
            timer.Elapsed += UpdateClock; // Подписываемся на событие Elapsed
            timer.AutoReset = true; // Устанавливаем автообновление
            timer.Enabled = true; // Включаем таймер
            UpdateClock(null, null); // Обновляем сразу при загрузке
        }

        private void OnUnloaded(object? sender, EventArgs e)
        {
            // Остановка и освобождение таймера
            timer?.Stop(); // Останавливаем таймер, если он не null
            timer?.Dispose(); // Освобождаем ресурсы
            timer = null; // Устанавливаем в null
        }

        private void UpdateClock(object? sender, ElapsedEventArgs e)
        {
            // Обновление интерфейса должно происходить в главном потоке
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ClockView.Invalidate(); // Обновляем графику часов
            });
        }
    }
}