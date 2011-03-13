InterpreterPlugin
	subclass: #BalloonEngineBase
	instanceVariableNames:
		'workBuffer objBuffer getBuffer aetBuffer spanBuffer engine formArray engineStopped geProfileTime dispatchedValue dispatchReturnValue objUsed doProfileStats copyBitsFn loadBBFn bbPluginName '
	classVariableNames: 'EdgeInitTable EdgeStepTable FillTable WideLineFillTable WideLineWidthTable '
	poolDictionaries: 'BalloonEngineConstants '
	category: 'VMConstruction-Plugins'