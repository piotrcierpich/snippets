using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace WpfApplication3
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = new ViewModel();
    }
  }

  class ViewModel : INotifyPropertyChanged, IDataErrorInfo
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public ViewModel()
    {
      TextChangedReads = new ObservableCollection<string>();
    }

    private string text = string.Empty;
    public string Text
    {
      get
      {
        TextChangedReads.Add("read: " + text);
        return text;
      }
      set
      {
        text = value;
        OnPropertyChanged("Text");
      }
    }

    public ObservableCollection<string> TextChangedReads { get; set; }

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public string this[string columnName]
    {
      get
      {
        return columnName == "Text" && text.Length < 5
                ? "Age must not be less than 0 or greater than 150."
                : null;
      }
    }

    public string Error { get { return null; } }
  }
}
