condExecuteWith: aRequestor
	self requestor: aRequestor.
	self executeCondition 
			ifTrue: [self execute] 
			ifFalse: [Beeper beep]