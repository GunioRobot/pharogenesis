buttonFlaps

	^self inFlapsSuppressedMode ifTrue: [
		self makeButton: 'Show tabs' balloonText: 'Show tabs' for: #toggleFlapsSuppressed
	] ifFalse: [
		self makeButton: 'Hide tabs' balloonText: 'Hide tabs' for: #toggleFlapsSuppressed
	].

