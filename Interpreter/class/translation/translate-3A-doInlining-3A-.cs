translate: fileName doInlining: inlineFlag
	"Time millisecondsToRun: [
		Interpreter translate: 'interp.c' doInlining: true.
		Smalltalk beep]"
	"Interpreter patchInterp: 'Squeak VM PPC'"

	self translate: fileName doInlining: inlineFlag forBrowserPlugin: false.
