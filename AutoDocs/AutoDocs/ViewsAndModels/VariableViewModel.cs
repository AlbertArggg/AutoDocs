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
            Variables.Add(new Variable("Test 1", "float", "private"));
            Variables.Add(new Variable("Test 2", "float", "private"));
            Variables.Add(new Variable("Test 3", "float", "private"));
            Variables.Add(new Variable("Test 4", "float", "private"));
            Variables.Add(new Variable("Test 5", "float", "private"));
        }
    }
}