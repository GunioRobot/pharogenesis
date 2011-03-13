snapshotBackgroundString
	^(self hasProperty: #backgroundSnapshot) 
		ifTrue:[^'<on>background snapshot'] 
		ifFalse:['<off>background snapshot'].