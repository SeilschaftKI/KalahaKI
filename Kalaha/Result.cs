using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalaha
{
    public class Result
    {
    	private int ScoreBlack;
		private int ScoreWhite;    	
    	
        private int duration { get; set; }

        public Result(int ScoreBlack, int ScoreWhite, int duration)
        {
        	this.ScoreBlack = ScoreBlack;
        	this.ScoreWhite = ScoreWhite;
        	this.duration = duration;        	
        		
        }



    }
}
