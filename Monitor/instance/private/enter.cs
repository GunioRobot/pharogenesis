enter
	self isOwnerProcess ifTrue: [
		nestingLevel _ nestingLevel + 1.
	] ifFalse: [
		mutex wait.
		ownerProcess _ Processor activeProcess.
		nestingLevel _ 1.
	].