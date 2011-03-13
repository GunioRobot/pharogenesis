collectSends
	| end |
	end _ self method endPC.
	[pc <= end]
		whileTrue: [self interpretNextInstructionFor: self]