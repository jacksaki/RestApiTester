using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using MahApps.Metro.Controls.Dialogs;
using RestApiTester.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace RestApiTester.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public void Initialize()
        {
        }
        public MainWindowViewModel()
        {
            this.DialogCoordinator = MahApps.Metro.Controls.Dialogs.DialogCoordinator.Instance;
            this.QueryStringBoxViewModel = new QueryStringBoxViewModel(this);
            this.QueryStringBoxViewModel.ErrorOccurred += ViewModel_ErrorOccurred;
            this.QueryStringBoxViewModel.Message += ViewModel_Message;
            this.RequestBodyBoxViewModel = new RequestBodyBoxViewModel(this);
            this.RequestBodyBoxViewModel.ErrorOccurred += ViewModel_ErrorOccurred;
            this.RequestBodyBoxViewModel.Message += ViewModel_Message;
            this.ResponseBoxViewModel = new ResponseBoxViewModel(this);
            this.ResponseBoxViewModel.ErrorOccurred += ViewModel_ErrorOccurred;
            this.ResponseBoxViewModel.Message += ViewModel_Message;
            this.ResponseInfoBoxViewModel = new ResponseInfoBoxViewModel(this);
            this.ResponseInfoBoxViewModel.ErrorOccurred += ViewModel_ErrorOccurred;
            this.ResponseInfoBoxViewModel.Message += ViewModel_Message;
            this.ResponseTypeBoxViewModel = new ResponseTypeBoxViewModel(this);
            this.ResponseTypeBoxViewModel.ErrorOccurred += ViewModel_ErrorOccurred;
            this.ResponseTypeBoxViewModel.Message += ViewModel_Message;
        }

        private async void ViewModel_Message(object sender, MessageEventArgs e)
        {
            await DialogCoordinator.ShowMessageAsync(this, e.Title, e.Message, MessageDialogStyle.Affirmative);
        }

        private async void ViewModel_ErrorOccurred(object sender, ErrorOccurredEventArgs e)
        {
            await DialogCoordinator.ShowMessageAsync(this, "エラー", $"{e.Message}\r\n{e.Exception.Message}", MessageDialogStyle.Affirmative);
        }

        public MahApps.Metro.Controls.Dialogs.IDialogCoordinator DialogCoordinator
        {
            get;
            set;
        }
        private void Menu_Message(object sender, MessageEventArgs e)
        {
            DialogCoordinator.ShowMessageAsync(this, e.Title, e.Message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
        }

        private void Menu_ErrorOccurred(object sender, ErrorOccurredEventArgs e)
        {
            DialogCoordinator.ShowMessageAsync(this, "エラー", e.Message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
        }


        public ResponseTypeBoxViewModel ResponseTypeBoxViewModel
        {
            get;
        }
        public QueryStringBoxViewModel QueryStringBoxViewModel
        {
            get;
        }
        public RequestBodyBoxViewModel RequestBodyBoxViewModel
        {
            get;
        }
        public ResponseBoxViewModel ResponseBoxViewModel
        {
            get;
        }
        public ResponseInfoBoxViewModel ResponseInfoBoxViewModel
        {
            get;
        }

        public RequestParameter Parameter
        {
            get;
        } = new RequestParameter();

        public ScreenshotParameter ScreenshotParameter
        {
            get;
        } = new ScreenshotParameter() { Ratio = 100f };

        private ViewModelCommand _ExecuteCommand;

        public ViewModelCommand ExecuteCommand
        {
            get
            {
                if (_ExecuteCommand == null)
                {
                    _ExecuteCommand = new ViewModelCommand(ExecuteAsync, CanExecute);
                }
                return _ExecuteCommand;
            }
        }

        public bool CanExecute()
        {
            try
            {
                this.Parameter.Validate();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async void ExecuteAsync()
        {
            DispatcherHelper.UIDispatcher.Invoke(() =>
            {
                Mouse.OverrideCursor = Cursors.Wait;
            });
            try
            {
                var response = await new RestApiExecutor().GetResultAsync(this.Parameter);
                this.ResponseInfoBoxViewModel.Response = response;
                this.ResponseBoxViewModel.Response = response;
            }
            catch (Exception ex)
            {
                await DialogCoordinator.ShowMessageAsync(this, "エラー", ex.Message, MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
            }
            finally
            {
                DispatcherHelper.UIDispatcher.Invoke(() =>
                {
                    Mouse.OverrideCursor = null;
                });
            }
        }


        private ViewModelCommand _ScreenshotCommand;

        public ViewModelCommand ScreenshotCommand
        {
            get
            {
                if (_ScreenshotCommand == null)
                {
                    _ScreenshotCommand = new ViewModelCommand(Screenshot, CanScreenshot);
                }
                return _ScreenshotCommand;
            }
        }

        public bool CanScreenshot()
        {
            return this.ScreenshotParameter.Ratio > 0f;
        }

        public void Screenshot()
        {

        }


    }
}
