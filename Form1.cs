using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms.NET__Async_Csharp__Split_Container__ProgressBar
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        //private const string APP_NAME = «MY_PREDICTOR";
        async private Task button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("1");
        }
        private CancellationTokenSource cancellationTokenSource;

        private async Task Funny(CancellationToken token)
        {
            string[] messages = new string[] {
        "Загрузка... Пожалуйста, подождите, пока наш кот не закончит свои утренние растяжки.",
        "Загрузка... Мы ищем потерянные носки. Они могут знать, где находится ваш контент!",
        "Загрузка... Похоже, наш сервер ушел на кофе. Вернется через 5 минут!",
        "Загрузка... Мы пытаемся найти кнопку 'Сделать всё быстро'. Она где-то здесь!",
        "Загрузка... Пожалуйста, не отключайте устройство. Мы находимся в процессе поиска вдохновения.",
        "Загрузка... Наши данные сейчас на свидании. Надеемся, они вернутся с хорошими новостями!",
        "Загрузка... Мы проверяем, не заблудились ли наши файлы в интернете."
    };
            string text = this.Text;
            while (!token.IsCancellationRequested)
            {
                var r = rnd.Next(messages.Length);
                this.Text = messages[r];
                await Task.Delay(2000); // Задержка для смены сообщения
            }
            this.Text = text;
        }

        private async void ClickMe_Click(object sender, EventArgs e)
        {
            
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            Task loading = Funny(token);

            for (int i = 1; i <= 100; i++)
            {
                await Task.Delay(100);
                progressBar1.Value = i;
            }

            // Отменяем задачу Funny
            cancellationTokenSource.Cancel();
            await loading; // Ждем завершения задачи
            progressBar1.Value = 0;
        }

    }
}
