new: size withAll: value 
	"Answer a new instance of me, whose every element is equal to the
	argument, value."

	size = 0 ifTrue: [^self new].
	^self runs: (OrderedCollection with: size) values: (OrderedCollection with: value)