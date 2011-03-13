detectSum: aBlock
	"Evaluate aBlock with each of the receiver's elements as the argument. 
	Return the sum of the answers."
	| sum |
	sum _ 0.
	self do: [:each | 
		sum _ (aBlock value: each) + sum].  
	^ sum