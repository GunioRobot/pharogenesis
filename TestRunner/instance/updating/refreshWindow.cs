refreshWindow
	| pc |
	pc _ self defaultBackgroundColor.
	passFailText isMorph
		ifTrue: [passFailText color: pc.
			detailsText color: pc]
		ifFalse: [passFailText insideColor: pc.
			detailsText insideColor: pc].
	self updateErrors: TestResult new.
	self updateFailures: TestResult new.
	self displayPassFail: 'N/A'.
	self displayDetails: '...'