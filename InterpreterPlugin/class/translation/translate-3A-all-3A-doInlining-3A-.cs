translate: fileName all: classes doInlining: inlineFlag
	"Time millisecondsToRun: [
		InterpreterPlugin translate:'all.c' all:{FloatArrayPlugin. FFTPlugin} doInlining: true.
		Smalltalk beep]"
	| cg theClass |
	cg _ self codeGeneratorClass new initialize.
	classes do:[:cls|
		theClass _ cls.
		theClass initialize.
		[theClass == InterpreterPlugin] whileFalse:[
			cg addClass: theClass.
			theClass declareCVarsIn: cg.
			theClass _ theClass superclass]].
	(classes includes: InterpreterPlugin) ifFalse:[
		cg addClass: InterpreterPlugin.
		InterpreterPlugin declareCVarsIn: cg].
	cg storeCodeOnFile: fileName doInlining: inlineFlag.