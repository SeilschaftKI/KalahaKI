using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalaha
{
    public class Result
    {
    	private int _score0;
		private int _score1;    	
		private int _duration;

        public Result(int Score0, int Score1, int duration)
        {
        	this._score0 = Score0;
        	this._score1 = Score1;
        	this._duration = duration;        		
        }
        
        public int Score0
        {
        	get{return _score0;}
        }
        
        public int Score1
        {
        	get{return _score1;}
        }



    }
}
