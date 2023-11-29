using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

	private async void AddTaskCLicked(object sender, EventArgs e)
	{
		var vm = BindingContext as NewTaskViewModel;

		if (string.IsNullOrWhiteSpace(vm.Task))
		{
			// Zeigt eine Fehlermeldung an, wenn kein Task-Name angegeben ist.
			await DisplayAlert("Invalid Entry", "You must enter a task name!", "Ok");
		}
		else
		{
			var selectedCategory = vm.Categories.FirstOrDefault(x => x.IsSelected);

			if (selectedCategory != null)
			{
				var task = new MyTask
				{
					TaskName = vm.Task,
					CategoryId = selectedCategory.Id,
				};
				vm.Tasks.Add(task);
				await Navigation.PopAsync();
			}
			else
			{
				// Zeigt eine Fehlermeldung an, wenn keine Kategorie ausgewählt ist.
				await DisplayAlert("Invalid Selection", "You must select a category!", "Ok");
			}
		}
	}
}