openNoSuspendDebugger: aDebugger label: aString 
	"Answer a standard system view containing an instance of me on the model, aDebugger. The label is aString. Do not terminate the current active process. "
	| debuggerView |
	debuggerView _ self debugger: aDebugger.
	debuggerView label: aString.
	debuggerView minimumSize: 300 @ 200.
	debuggerView controller openNoTerminate.
	^ debuggerView