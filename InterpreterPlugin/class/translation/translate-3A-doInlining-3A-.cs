translate: fileName doInlining: inlineFlag
	"Time millisecondsToRun: [
		FloatArrayPlugin translate: 'SqFloatArray.c' doInlining: true.
		Smalltalk beep]"
	^self translate: fileName doInlining: inlineFlag locally: false.