using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RemoteMusicController.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        private readonly decimal currentRate = 64.1m;
        public void OnGet()
        {
            Message = "¬ведите сумму";
        }
        public void OnPost(string? ButtonType)
        {
            if(ButtonType== "Play/Pause")
                KButton.List.FirstOrDefault(x => x.Button == Button.Play_Pause).Press(); ;
            if (ButtonType == "Volume Up")
                KButton.List.FirstOrDefault(x => x.Button == Button.VolumeUp).Press(); ;
            if (ButtonType == "Volume Down")
                KButton.List.FirstOrDefault(x => x.Button == Button.VolumeDown).Press();
            if (ButtonType == "Next")
                KButton.List.FirstOrDefault(x => x.Button == Button.Next).Press();
            if (ButtonType == "Prev")
                KButton.List.FirstOrDefault(x => x.Button == Button.Prev).Press();
        }
    }
}