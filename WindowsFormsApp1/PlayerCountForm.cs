using System;
using System.Windows.Forms;

namespace BoardGameUI
{
    public partial class PlayerCountForm : Form
    {
        public int PlayerCount { get; private set; } // Выбранное количество игроков

        public PlayerCountForm()
        {
            InitializeComponent(); // Инициализация компонентов
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PlayerCount = (int)numericUpDownPlayers.Value; // Получаем значение из NumericUpDown
            DialogResult = DialogResult.OK; // Устанавливаем результат как OK
            Close(); // Закрываем окно
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Устанавливаем результат как Cancel
            Close(); // Закрываем окно
        }
    }
}
