contentsOfEntireFile
	"Read all of the contents of the receiver."

	| s binary |
	self readOnly.
	binary _ self isBinary.
	self reset.	"erases knowledge of whether it is binary"
	binary ifTrue: [self binary].
	s _ self next: self size.
	self close.
	^s