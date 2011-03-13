emitStore: stack on: aStream

	aStream nextPut: Dup. stack push: 1.
	self emitStorePop: stack on: aStream