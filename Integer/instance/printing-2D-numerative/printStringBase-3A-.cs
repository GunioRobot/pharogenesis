printStringBase: base
	| stream integer next |
	self = 0 ifTrue: [^'0'].
	self negative ifTrue: [^'-', (self negated printStringBase: base)].
	stream _ WriteStream on: String new.
	integer _ self normalize.
	[integer > 0] whileTrue: [
		next _ integer quo: base.
		stream nextPut: (Character digitValue: integer - (next * base)).
		integer _ next].
	^stream contents reversed

