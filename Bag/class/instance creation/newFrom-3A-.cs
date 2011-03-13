newFrom: aCollection 
	"Answer an instance of me containing the same elements as aCollection."

	| newCollection |
	newCollection _ self new.
	newCollection addAll: aCollection.
	^newCollection

"	Bag newFrom: {1. 2. 3}
	{1. 2. 3} as: Bag
"