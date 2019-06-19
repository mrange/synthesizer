using NAudio.Wave.SampleProviders;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace synthesizer
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel(Dispatcher);
            DataContext = _viewModel;
            Closing += ((obj, e) => _viewModel.OffCommand.Execute(null));
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            _viewModel.KeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            _viewModel.KeyUp(e);
        }

        private void Octave2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selected = comboBox.SelectedIndex;

            if (_viewModel != null)
            {
                _viewModel.Voice2Octave = selected * 12;
            }
        }

        private void Octave3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selected = comboBox.SelectedIndex;

            if (_viewModel != null)
            {
                _viewModel.Voice3Octave = selected * 12;
            }
        }

        private void Semitone2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selected = comboBox.SelectedIndex;

            if (_viewModel != null)
            {
                _viewModel.Voice2Semi = selected;
            }
        }

        private void Semitone3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selected = comboBox.SelectedIndex;

            if (_viewModel != null)
            {
                _viewModel.Voice3Semi = selected;
            }
        }
    }
}
