context: thisCntx hasSender: aContext 
	"Does thisCntx have aContext in its sender chain?"
	| s nilOop |
	self inline: true.
	thisCntx == aContext ifTrue: [^false].
	nilOop _ nilObj.
	s _ self fetchPointer: SenderIndex ofObject: thisCntx.
	[s == nilOop]
		whileFalse: [s == aContext ifTrue: [^true].
			s _ self fetchPointer: SenderIndex ofObject: s].
	^false