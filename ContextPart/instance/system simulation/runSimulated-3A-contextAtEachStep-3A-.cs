runSimulated: aBlock contextAtEachStep: block2
	"Simulate the execution of the argument, aBlock, until it ends. aBlock 
	MUST NOT contain an '^'. Evaluate block2 with the current context 
	prior to each instruction executed. Answer the simulated value of aBlock."

	| current |
	(aBlock isBlock and: [aBlock hasMethodReturn])
		ifTrue: [self error: 'simulation of blocks with ^ can run loose'].
	current _ aBlock asContext.
	current privSender: self.
	[current == self]
		whileFalse:
			[block2 value: current.
			current _ current step].
	^ self pop