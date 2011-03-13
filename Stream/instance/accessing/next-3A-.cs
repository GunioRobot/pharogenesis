next: anInteger 
	"Answer the next anInteger number of objects accessible by the receiver."

	| aCollection |
	aCollection _ OrderedCollection new.
	anInteger timesRepeat: [aCollection addLast: self next].
	^aCollection