time: anObject
	"Set the receiver's instance variable 'time' to be anObject."
	(anObject isKindOf: String)
		ifTrue: [time _ anObject asTime]
		ifFalse: [time := anObject]