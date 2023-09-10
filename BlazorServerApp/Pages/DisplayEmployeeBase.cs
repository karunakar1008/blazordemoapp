using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServerApp.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        protected bool IsSelected { get; set; }

        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            IsSelected = (bool)e.Value;
            await OnEmployeeSelection.InvokeAsync(IsSelected);
        }
    }
}
