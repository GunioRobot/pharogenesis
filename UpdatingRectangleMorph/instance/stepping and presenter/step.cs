step
	| s |
	super step.
	s _ self readFromTarget.
	s = contents ifFalse:
		[self contents: s.
		self color: s]
