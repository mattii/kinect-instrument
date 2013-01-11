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
	[PluginInfo(Name = "SpreadBuffer", Category = "Value", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class ValueSpreadBufferNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0.0)]
		ISpread<double> FInput;
		
		[Input("Insert", DefaultValue = 0, IsBang = true, IsSingle = true)]
		ISpread<bool> FInsert;
		
		[Input("Reset", DefaultValue = 0, IsBang = true, IsSingle = true)]
		ISpread<bool> FReset;
		
		[Output("Output")]
		ISpread<double> FOutput;
		
		[Output("Output Bin Size")]
		ISpread<int> FOutputBinSize;
		
		[Import()]
		ILogger FLogger;
		#endregion fields & pins

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
	
			if(FInsert[0]) {
				if(FOutput.SliceCount == 1) {
					FOutput.SliceCount = 0;
					FOutputBinSize.SliceCount = 0;
				}
				
				for (int i = 0; i < FInput.SliceCount; i++) {
					FOutput.Add(FInput[i]);
				}
				FOutputBinSize.Add(FInput.SliceCount);				
			}
			
			if(FReset[0]) {
				FOutput.SliceCount = 0;
				FOutputBinSize.SliceCount = 0;
			}
		}
	}
}
