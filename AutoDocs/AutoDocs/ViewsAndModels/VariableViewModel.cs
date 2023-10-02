using System.Collections.ObjectModel;
using AutoDocs.Structure.DTOs;

namespace AutoDocs
{
    public class VariableViewModel
    {
        public ObservableCollection<Variable> Variables { get; set; }

        public VariableViewModel()
        {
            Variables = new ObservableCollection<Variable>();
        }
    }
}