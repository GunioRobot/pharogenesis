translateForBrowserPlugin: fileName
	"NOTE: For other than Mac, see the comment in
		#translate:doInlining:forBrowserPlugin:
	"
	"Time millisecondsToRun: [
		Interpreter translateForBrowserPlugin: 'pluginInterp.c'.
		Smalltalk beep]"
	"Interpreter patchInterp: 'Squeak VM PPC'"

	self translate: fileName doInlining: true forBrowserPlugin: true.
