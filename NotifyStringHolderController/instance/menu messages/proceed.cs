proceed
	"Proceed execution of the suspended process."
	| debuggerTemp |
	Smalltalk okayToProceedEvenIfSpaceIsLow ifFalse: [^ self].
	debuggerTemp _ debugger.  debugger _ nil.  "So close wont terminate"
	self controlTerminate.
	debuggerTemp proceed: view superView controller.
	self controlInitialize