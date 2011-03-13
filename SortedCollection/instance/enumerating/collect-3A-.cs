collect: aBlock 
	"Evaluate aBlock with each of my elements as the argument. Collect the 
	resulting values into an OrderedCollection. Answer the new collection. 
	Override the superclass in order to produce an OrderedCollection instead
	of a SortedCollection."

	| newCollection | 
	newCollection _ OrderedCollection new.
	self do: [:each | newCollection add: (aBlock value: each)].
	^newCollection