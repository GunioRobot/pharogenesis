isTerminated

	self isActiveProcess ifTrue: [^ false].
	^ suspendedContext isNil or: [
		suspendedContext == suspendedContext bottomContext and: [
			suspendedContext pc > suspendedContext startpc]]