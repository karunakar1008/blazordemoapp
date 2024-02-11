using Microsoft.AspNetCore.Components;

namespace BlazorServerApp.Pages
{
    public class DataBinding1Base : ComponentBase
    {
        protected string Name { get; set; } = "Tom";
        protected string Gender { get; set; } = "Male";
    }
}
