runTest: aSelector

	| expectedResult |
	[expectedResult := self perform: (aSelector, #Results) asSymbol.
	self logTest: aSelector.
	self clearLog.
	self perform: aSelector.
	] on: MyTestError
	  do: 
		[ :ex |
		self log: 'Unhandled Exception'.
		ex return: nil].
	self log = expectedResult
		ifTrue: [self logTestResult: 'succeeded']
		ifFalse: [self logTestResult: 'failed']