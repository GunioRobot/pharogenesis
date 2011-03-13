branch
	"This method is never run. It is here just so that the sends in it can be
	tallied by the SendInfo interpreter."
	(state
		ifNil: [self]
		ifNotNil: [state]) clip.
	(state isNil
		ifTrue: [self]
		ifFalse: [state]) truncate.
