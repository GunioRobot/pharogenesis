xValue: xValue from: firstIndex do: aBlock
	"Enumerate the entries in the insertion list starting at the given first index.
	Evaluate aBlock with the entries having the requested x value. Return the index
	after the last element touched."
	| edge |
	firstIndex to: tally do:[:i|
		edge _ array at: i.
		edge xValue = xValue ifFalse:[^i].
		aBlock value: edge.
	].
	^tally+1