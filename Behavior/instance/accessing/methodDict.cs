methodDict
	methodDict == nil ifTrue: [self recoverFromMDFault].
	^ methodDict