release
	| debuggerTemp |
	debugger == nil
		ifTrue: [super release]
		ifFalse:
			[debuggerTemp _ debugger.  debugger _ nil.
			view release.  "This will finish view release without termination"
			debuggerTemp release  "This will cause termination"]