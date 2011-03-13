newFrom: aCollection 
	"Answer an instance of me containing the same elements as aCollection."
	| newCollection |
	newCollection _ self new: aCollection size.
	newCollection addAll: aCollection.
	^ newCollection
"
	Set newFrom: {1. 2. 3}
	{1. 2. 3} as: Set
"