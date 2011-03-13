objectIfBlocked: anObject
	"See if this object is blocked -- not written out and another object substituted."

	^ (blockers includesKey: anObject) 
		ifTrue: [blockers at: anObject]
		ifFalse: [anObject]