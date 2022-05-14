using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using TextTransformationToolForWin.Model;
using TextTransformationTool.Core;

namespace TextTransformationToolForWin.Command
{
    public class TransactionToolButtonCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly TransformationToolModel _model;

        private readonly ITextTransformation _transformationExecutor;

        public TransactionToolButtonCommand(TransformationToolModel model, ITextTransformation transformationExecutor)
        {
            _model = model;
            _transformationExecutor = transformationExecutor;
        }


        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _model.Output = _transformationExecutor.Transform(_model.Input);
        }
    }
}
