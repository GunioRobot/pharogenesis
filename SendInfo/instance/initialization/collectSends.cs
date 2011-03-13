collectSends
	| end |
	end := self method endPC.
	[pc <= end]
		whileTrue: [self interpretNextInstructionFor: self]