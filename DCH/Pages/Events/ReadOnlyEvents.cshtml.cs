using DCH.Interfaces;
using DCH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DCH.Pages.Events
{
    public class ReadOnlyEventsModel : PageModel
    {
        private IEventRepository catalog;
        public int ClickCount { get; set; } = 0;
        public Dictionary<int, Event> FilteredEvents { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public ReadOnlyEventsModel(IEventRepository cat)
        {
                catalog = cat;
        }
        public Dictionary<int, Event> Events { get; private set; }
        public IActionResult OnGet()
        {
            Events = catalog.AllEvents();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = catalog.FilterEvents(FilterCriteria);
            }
            return Page();
        }

        // ClickCount tæller hver gang der klikkes på tilmeld --> virker ikke
        public IActionResult OnPostBottunClick()
        {
            //if (Events.ContainsKey(id))
            //{
            ClickCount++;
            //}
            return Page();
        }
    }
}

