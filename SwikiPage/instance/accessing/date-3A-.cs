date: anObject
	"Set the receiver's instance variable 'date' to be anObject."

		(anObject isKindOf: String)
			ifTrue: [date _ anObject asDate]
			ifFalse: [date := anObject]