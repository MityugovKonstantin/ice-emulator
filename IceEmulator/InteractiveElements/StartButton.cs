using System.Windows.Controls;

namespace View.InteractiveElements
{
    /// <summary>Our button for start/stop emulator</summary>
    class StartButton : Button
    {
        private bool _isEnable = false;

        // override funtion for enable/disable parameter in start button
        protected override void OnClick()
        {
            base.OnClick();
            _isEnable = !_isEnable;
            if (_isEnable)
            {
                Content = "Завершить";
                Logger.AddLog("[StartButton] => Начало работы двигателя");
            }
            else
            {
                Content = "Начать";
                Logger.AddLog("[StartButton] => Завершение работы двигателя");
            }
        }


        /// <returns>True if start button enabled or false if start button is disabled</returns>
        public bool GetIsEnable()
        {
            return _isEnable;
        }
    }
}
