doWithIndex: aBlock 
	"Just like do: except that the index is supplied also.
	Beware -- the block must accept two arguments, the object
	in the collection and its index."

	| index length |
	index _ 0.
	length _ self size.
	[(index _ index + 1) <= length]
		whileTrue: [aBlock value: (self at: index) value: index]

"compute the sum of the distances from the right places in a permutation.
	| sum |  sum _ 0.  #(3 5 4 1 2) doWithIndex: [:each :index |
		sum _ sum + (each - index) abs].
	sum    "