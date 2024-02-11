using Microsoft.AspNetCore.Components;

namespace BlazorServerApp.Pages
{
    public class Databinding2Base : ComponentBase
    {
        protected string Name { get; set; } = "Tom";

        protected string Colour { get; set; } = "background-color:red";
    }
}
