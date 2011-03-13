condExecuteFor: aRequestor
	^ (self isEnabledFor: aRequestor)
		 ifTrue: [self executeFor: aRequestor]