jump: distance 
	"Simulate the action of a 'unconditional jump' bytecode whose  
	offset is the argument, distance."
	distance < 0
		ifTrue: [^ self].
	distance = 0
		ifTrue: [self error: 'bad compiler!'].
	savedStacks at: (self pc + distance) put: stack.
	"We empty the stack to signify that execution cannot 'fall through' to the
	next statement.  Note that since we just stored the current stack, not a copy, in
	the savedStacks dictionary, here we need to allocate a new stack."
	self newEmptyStack.  
	isStartOfBlock
		ifTrue: [isStartOfBlock := false.
			numBlockArgs	timesRepeat: [self push: #stuff]]