using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rankings_Calculator_Page.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public int p1Points { get; set; }
    [BindProperty]
    public int p2Points { get; set;}
    [BindProperty]
    public double weight { get; set; }
    [BindProperty]
    public bool win1 { get; set; }
    public int newp1 { get; set; }
    public int newp2 { get; set; }


    private readonly ILogger<IndexModel> _logger;
    

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnPost()
    {
        var results = CalculateNewPoints(p1Points,p2Points, weight, win1);
        newp1 = results.n1;
        newp2 = results.n2;
    }
    public (int n1, int n2) CalculateNewPoints(int p1Points, int p2Points, double weight, bool win1)
    {
        int band;
        bool p1Expected;
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
        bool expected;
        if (win1 && p1Expected)
        {
            expected = true;
        }
        else if (!win1 && !p1Expected)
        {
            expected = true;
        }
        else
        {
            expected = false;
        }
        // hard logic for me :(

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

        /* if win1 is true, then player 1 has won else player two has won.
            if expected is true, the result is expected
        */

        //// work out player one's gain
        
        int p1Gain = 0;
        int p2Gain = 0;
        // expected wins for player 1
        if (expected && win1)
        {
            if (band == 1)
            {
                p1Gain = 8;
            }
            else if (band == 2)
            {
                p1Gain = 7;
            }
            else if (band == 3)
            {
                p1Gain = 6;
            }
            else if (band == 4)
            {
                p1Gain = 5;
            }
            else if (band == 5)
            {
                p1Gain = 4;
            }
            else if (band == 6)
            {
                p1Gain = 3;
            }
            else if (band == 7)
            {
                p1Gain = 2;
            }
            else
            {
                p1Gain = 1;
            }
        }
        // unexpected wins for player 1
        else if (!expected && win1)
        {
            if (band == 1)
            {
                p1Gain = 8;
            }
            else if (band == 2)
            {
                p1Gain = 9;
            }
            else if (band == 3)
            {
                p1Gain = 11;
            }
            else if (band == 4)
            {
                p1Gain = 14;
            }
            else if (band == 5)
            {
                p1Gain = 17;
            }
            else if (band == 6)
            {
                p1Gain = 22;
            }
            else if (band == 7)
            {
                p1Gain = 30;
            }
            else if (band == 8)
            {
                p1Gain = 40;
            }
            else
            {
                p1Gain = 50;
            }
        }
        // expected losses for player 1
        else if (expected && !win1)
        {
            if (band == 1)
            {
                p1Gain = -4;
            }
            else if (band == 2)
            {
                p1Gain = -4;
            }
            else if (band == 3)
            {
                p1Gain = -3;
            }
            else if (band == 4)
            {
                p1Gain = -3;
            }
            else if (band == 5)
            {
                p1Gain = -2;
            }
            else if (band == 6)
            {
                p1Gain = -2;
            }
            else if (band == 7)
            {
                p1Gain = -1;
            }
            else
            {
                p1Gain = 0;
            }

        }
        // unexpected losses for player 1
        else if (!expected && !win1)
        {
            if (band == 1)
            {
                p1Gain = -4;
            }
            else if (band == 2)
            {
                p1Gain = -4;
            }
            else if (band == 3)
            {
                p1Gain = -6;
            }
            else if (band == 4)
            {
                p1Gain = -8;
            }
            else if (band == 5)
            {
                p1Gain = -10;
            }
            else if (band == 6)
            {
                p1Gain = -12;
            }
            else if (band == 7)
            {
                p1Gain = -16;
            }
            else if (band == 8)
            {
                p1Gain = -20;
            }
            else
            {
                p1Gain = -26;
            }
        }

        // now same for player two!

        // expected win
        if (expected && !win1)
        {
            if (band == 1)
            {
                p2Gain = 8;
            }
            else if (band == 2)
            {
                p2Gain = 7;
            }
            else if (band == 3)
            {
                p2Gain = 6;
            }
            else if (band == 4)
            {
                p2Gain = 5;
            }
            else if (band == 5)
            {
                p2Gain = 4;
            }
            else if (band == 6)
            {
                p2Gain = 3;
            }
            else if (band == 7)
            {
                p2Gain = 2;
            }
            else
            {
                p2Gain = 1;
            }
        }

        // un-expected WIn

        else if (!expected && !win1)
        {
            if (band == 1)
            {
                p2Gain = 8;
            }
            else if (band == 2)
            {
                p2Gain = 9;
            }
            else if (band == 3)
            {
                p2Gain = 11;
            }
            else if (band == 4)
            {
                p2Gain = 14;
            }
            else if (band == 5)
            {
                p2Gain = 17;
            }
            else if (band == 6)
            {
                p2Gain = 22;
            }
            else if (band == 7)
            {
                p2Gain = 30;
            }
            else if (band == 8)
            {
                p2Gain = 40;
            }
            else
            {
                p2Gain = 50;
            }
        }

        // expected loss
        else if (expected && win1)
        {
            if (band == 1)
            {
                p2Gain = -4;
            }
            else if (band == 2)
            {
                p2Gain = -4;
            }
            else if (band == 3)
            {
                p2Gain = -3;
            }
            else if (band == 4)
            {
                p2Gain = -3;
            }
            else if (band == 5)
            {
                p2Gain = -2;
            }
            else if (band == 6)
            {
                p2Gain = -2;
            }
            else if (band == 7)
            {
                p2Gain = -1;
            }
            else
            {
                p2Gain = 0;
            }
        }
        // un-Expected LOSS
        else if (!expected && win1)
        {
            if (band == 1)
            {
                p2Gain = -4;
            }
            else if (band == 2)
            {
                p2Gain = -4;
            }
            else if (band == 3)
            {
                p2Gain = -6;
            }
            else if (band == 4)
            {
                p2Gain = -8;
            }
            else if (band == 5)
            {
                p2Gain = -10;
            }
            else if (band == 6)
            {
                p2Gain = -12;
            }
            else if (band == 7)
            {
                p2Gain = -16;
            }
            else if (band == 8)
            {
                p2Gain = -20;
            }
            else
            {
                p2Gain = -26;
            }
        }
        //// multiply by weight
        p1Gain = (int)Math.Round(p1Gain * weight, MidpointRounding.AwayFromZero);
        p2Gain = (int)Math.Round(p2Gain * weight, MidpointRounding.AwayFromZero);

        //// output points
        return(p1Points + p1Gain, p2Points + p2Gain);
        
    }
}
