doItWith: anApplescriptInstance in: aContext mode: anInteger

	| resultID displayResult |
	resultID _ anApplescriptInstance executeOSAID: self in: aContext mode: anInteger.
	resultID ifNil: [^nil].
	displayResult _ anApplescriptInstance 
		displayAndDisposeOSAID: resultID 
		as: 'TEXT' 
		mode: anInteger.
	displayResult ifNil: [^nil].
	^displayResult asStringThenDispose