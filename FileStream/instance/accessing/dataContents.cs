dataContents
	"Read most of the contents of the receiver."
	| s |
	s _ self size < 4000
		ifTrue: [self next: self size]
		ifFalse: [self next: 4000].
	self close.
	^s