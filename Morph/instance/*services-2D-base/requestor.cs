requestor
	^ owner ifNil: [super requestor] ifNotNil: [owner requestor]