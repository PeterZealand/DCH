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

        public Actor Actor { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Source { get; set; }

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

        // ClickCount tæller hver gang der klikkes på tilmeld --> virker men kan klikkes op uendeligt og hænger ikke sammen med et actor ID endnu

        public IActionResult OnPost(int eventId)
        {
            Events = catalog.AllEvents();
            if (Events.ContainsKey(eventId))
            {
                Events[eventId].ClickCount++;
                catalog.UpdateEvent(Events[eventId]);
            }

            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = catalog.FilterEvents(FilterCriteria);
            }
            return Page();
        }
        //public IActionResult OnPostButtonClick()
        //{
        //    //if (Events.ContainsKey(id))
        //    //{
        //    ClickCount++;
        //    //}
        //    return Page();
        //}
    }
}

