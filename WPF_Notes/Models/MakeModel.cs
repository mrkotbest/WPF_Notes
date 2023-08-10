using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Notes.Models
{
    class MakeModel : INotifyPropertyChanged
    {
        private bool _isDone;
        private string _note;

        public DateTime Date { get; set; } = DateTime.Now;
		public bool IsDone
		{
			get { return _isDone; }
			set 
			{
				if (_isDone == value) return;
				_isDone = value;
				OnPropertyChanged("IsDone");
			}
		}
		public string Note
		{
			get { return _note; }
			set
			{
				if (_note == value) return;
				_note = value;
				OnPropertyChanged("Note");
			}
		}

        public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
