using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TextTransformationToolForWin.Command;
using TextTransformationToolForWin.Model;
using TextTransformationTool.Core;
using TextTransformationTool.Core.Simple;
using TextTransformationTool.Core.NamingCase;
using TextTransformationTool.Core.Compound;

namespace TextTransformationToolForWin.ViewModel
{
    internal class TransFormationToolViewModel : INotifyPropertyChanged
    {
        private TransformationToolModel Model { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public TransactionToolButtonCommand ToLowerCommand { get; }
        public TransactionToolButtonCommand ToUpperCommand { get; }
        public TransactionToolButtonCommand ToCamelCaseCommand { get; }
        public TransactionToolButtonCommand ToPascalCaseCommand { get; }
        public TransactionToolButtonCommand ToLowerSnakeCaseCommand { get; }
        public TransactionToolButtonCommand ToUpperSnakeCaseCommand { get; }

        public TransFormationToolViewModel()
        {
            Model = new TransformationToolModel();
            Model.PropertyChanged += OnModelPropertyChenged;

            var factory = new TextTransformationFactory();
            ToLowerCommand = new TransactionToolButtonCommand(Model, factory.Create(TextTransformationMode.ToLower));
            ToUpperCommand = new TransactionToolButtonCommand(Model, factory.Create(TextTransformationMode.ToUpper));
            ToCamelCaseCommand = new TransactionToolButtonCommand(Model, factory.Create(TextTransformationMode.ToCamelCase));
            ToPascalCaseCommand = new TransactionToolButtonCommand(Model, factory.Create( TextTransformationMode.ToPascalCase));
            ToLowerSnakeCaseCommand = new TransactionToolButtonCommand(Model, factory.Create(TextTransformationMode.ToLowerSnakeCase));
            ToUpperSnakeCaseCommand = new TransactionToolButtonCommand(Model, factory.Create(TextTransformationMode.ToUpperSnakeCase));
        }

        public string Input
        {
            get { return Model.Input; }
            set
            {
                Model.Input = value;
                RaisePropertyChanged();
            }
        }

        public string Output
        {
            get { return Model.Output; }
            set
            {
                Model.Output = value;
                RaisePropertyChanged();
            }
        }

        public void OnModelPropertyChenged(object? sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName ?? "");
        }


        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
    }
}
