firstPersonControlString
	^(self doFirstPersonControl) 
		ifTrue:[^'<on>first person control'] 
		ifFalse:['<off>first person control'].