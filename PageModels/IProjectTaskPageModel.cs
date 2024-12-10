using CommunityToolkit.Mvvm.Input;
using LLLAABA2.Models;

namespace LLLAABA2.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}