translateDoInlining: inlineFlag 
	"Time millisecondsToRun: [ 
		FloatArrayPlugin translateDoInlining: true. 
		Smalltalk beep]"

	^ self translate: self moduleName , self moduleExtension doInlining: inlineFlag