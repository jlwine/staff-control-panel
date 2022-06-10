using Microsoft.AspNetCore.Mvc.Rendering;

namespace staff_control_panel.Models
{
    public class NavigationProperty
    {
        public class EmployeeListViewModel
        {
            public IEnumerable<Employee> Employees { get; set; }
            public SelectList Posts { get; set; }

        }
    }
}
