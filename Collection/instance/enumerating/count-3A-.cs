count: aBlock
	"Evaluate aBlock with each of the receiver's elements as the argument.  Return the number that answered true."

	| sum |
	sum _ 0.
	self do: [:each | 
		(aBlock value: each) ifTrue: [sum _ sum + 1]].
	^ sum