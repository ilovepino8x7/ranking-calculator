using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rankings_Calculator_Page.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    [BindProperty]
    public int mePoints {get; set;}
    [BindProperty]
    public int themPoints {get; set;}
    [BindProperty]
    public double weight {get; set;}
    [BindProperty]
    public bool p1win {get; set;}
    public bool p1Expected;
    public int band;
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
    public void CalculateNewPoints(int p1Points, int p2Points, double weight, bool win1)
    {
        if (p1Points >= p2Points)
        {
            p1Expected = true;
        }
        else
        {
            p1Expected = false;
        }
        int diff = p1Points - p2Points;
        if (diff < 0)
        {
            diff = p2Points - p1Points;
        } 
        // complex logic :(

        // work out band
        if (diff <= 24)
        {
            band = 1;
        }
        else if (diff <= 49)
        {
            band = 2;
        }
        else if (diff <= 99)
        {
            band = 3;
        }
        else if (diff <= 149)
        {
            band = 4;
        }
        else if (diff <= 199)
        {
            band = 5;
        }
        else if (diff <= 299)
        {
            band = 6;
        }
        else if (diff <= 399)
        {
            band = 7;
        }
        else if (diff <= 499)
        {
            band = 8;
        }
        else
        {
            band = 9;
        }
    }
}
