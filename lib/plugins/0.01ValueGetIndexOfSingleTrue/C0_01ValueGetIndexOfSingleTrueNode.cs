#region usings
using System;
using System.ComponentModel.Composition;

using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
using VVVV.Utils.VMath;

using VVVV.Core.Logging;
#endregion usings

namespace VVVV.Nodes
{
	#region PluginInfo
	[PluginInfo(Name = "GetIndexOfSingleTrue", Category = "Value", Version = "0.01", Help = "Returns index of values in a spread that are part a given range", Tags = "")]
	#endregion PluginInfo
	public class C0_01ValueGetIndexOfSingleTrueNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("SpreadIn", DefaultValue = 1.0)]
		ISpread<double> FInput;
		
		[Input("Min", DefaultValue = 1.0)]
		ISpread<double> FMin;
		
		[Input("Max", DefaultValue = 10)]
		ISpread<double> FMax;

		[Output("Output")]
		ISpread<double> FOutput;

		[Import()]
		ILogger FLogger;
		#endregion fields & pins

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			FOutput.SliceCount = 0;
			int trueCount = 0;

			for (int i = 0; i < SpreadMax; i++)
				if((FInput[i] >= FMin[0])&&(FInput[i] <= FMax[0])){
					int addEl = i;
					FOutput.Add(addEl);
				}
			//FLogger.Log(LogType.Debug, "hi tty!");
		}
	}
}
