debug
	"Open a full DebuggerView."
	| debuggerTemp topView |
	topView _ view topView.
	debuggerTemp _ debugger.  debugger _ nil.  "So close wont terminate"
	self controlTerminate.
	topView deEmphasizeView; erase.
	DebuggerView openNoSuspendDebugger: debuggerTemp label: topView label.
	topView controller closeAndUnscheduleNoErase.
	Processor terminateActive