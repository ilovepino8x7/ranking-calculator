using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rankings_Calculator_Page.Pages;

public class FinalModel : PageModel
{
    public int p1Points { get; set; }
    public int p2Points { get; set;}
    public string p1Name { get; set; } = "Player One";
    public string p2Name { get; set; } = "Player Two";
    public void OnGet(int p1Points, int p2Points, string p1Name, string p2Name)
    {
        this.p1Points = p1Points;
        this.p2Points = p2Points;
        this.p1Name = p1Name;
        this.p2Name = p2Name;
        if (p1Points < 100)
        {
            this.p1Points = 100;
            p1Points = 100;
        }
        if (p2Points < 100)
        {
            this.p2Points = 100;
            p2Points = 100;
        }
        if (p1Name == null)
        {
            this.p1Name = "Player One (" + p1Points.ToString() + ")";
        }
        if (p2Name == null)
        {
            this.p2Name = "Player Two (" + p2Points.ToString() + ")";
        }
    }
}