using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class LuaTest : MonoBehaviour {

	Script script;


	string fact = @"    
		-- defines a factorial function
		function fact (n)
			if (n == 0) then
				return 1
			else
				return n*fact(n - 1)
			end
		end
		";
	string multiFact = @"    
		-- defines a factorial function
		function multiFact (n)
			res = 0
			for i=0, n - 1, 1 do
				res = res + fact(7)
			end
			return res;
		end
		";
	string emptyFunc = @"    
		-- defines a factorial function
		function empty ()
			return 1
		end
		";
		
	// Use this for initialization
	void Start () {
		script = new Script ();
		script.DoString (fact);
		script.DoString (multiFact);
		script.DoString (emptyFunc);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(MoonSharpFactorialMultipleCalls (1000));
		//Debug.Log(MoonSharpFactorialOneCall (1000));
		Debug.Log(MoonSharpEmptyFunc (1000));
		//Debug.Log(test2(7000));
	}

	double MoonSharpFactorialMultipleCalls(int times)
	{

		if (times == 0)
			return 0;

		double res = script.Call(script.Globals["fact"], 7).Number;

		for(int i = 0; i < times - 1; i++)
			res += script.Call(script.Globals["fact" + Random.Range(0,3)], 7).Number;

		return res;
	}
	double MoonSharpFactorialOneCall(int times)
	{

		double res = script.Call(script.Globals["multiFact"], times).Number;

		return res;
	}
	double MoonSharpEmptyFunc(int times)
	{
		double total = 0;
		for(int i = 0; i < times - 1; i++)
			total += script.Call(script.Globals["empty"]).Number;
		return total;
	}

	double test2(int times){
	
		double total = 0;
		for (int i = 0; i < times - 1; i++)
			total += test (0);
		return total;
	
	}

	double test(int a){
		
		return a + 1;
	
	}

}
