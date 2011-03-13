subclasses
	"Answer a Set containing the receiver's subclasses."

	subclasses == nil
		ifTrue: [^Set new]
		ifFalse: [^subclasses copy]