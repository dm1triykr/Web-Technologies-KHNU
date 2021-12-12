using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab1.Views.Shared.Components.Topbar
{
    public class TopbarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            TopbarViewModel vm = new TopbarViewModel()
            {
                IsAdminUser = false
            };
            return View(vm);
        }
    }
}
