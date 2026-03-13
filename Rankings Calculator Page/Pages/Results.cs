using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rankings_Calculator_Page.Pages;

public class ResultsModel : PageModel
{
    public int p1Points { get; set; }
    public int p2Points { get; set;}
    public bool p1Win { get; set; }
    public double weight { get; set; }
    public void OnGet(int p1Points, int p2Points, bool p1Win, double weight)
    {
        this.p1Points = p1Points;
        this.p2Points = p2Points;
        this.p1Win = p1Win;
        this.weight = weight;
    }
}