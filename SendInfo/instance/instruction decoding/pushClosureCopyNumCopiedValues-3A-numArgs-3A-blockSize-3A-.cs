pushClosureCopyNumCopiedValues: numCopied numArgs: numArgs blockSize: blockSize
	"Simulate the action of a 'closure copy' bytecode whose result is the
	 new BlockClosure for the following code"
	self pop: numCopied.
	self push: #block.
	savedStacks at: (self pc + blockSize) put: stack.
	"We empty the stack to signify that execution cannot 'fall through' to the
	next statement.  Note that since we just stored the current stack, not a copy, in
	the savedStacks dictionary, here we need to allocate a new stack."
	self newEmptyStack.
	numCopied + numArgs timesRepeat: [self push: #stuff]