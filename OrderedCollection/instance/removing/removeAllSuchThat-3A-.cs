removeAllSuchThat: aBlock 
	"Evaluate aBlock for each element and remove all that elements from
	the receiver for that aBlock evaluates to true."

	| index |
	index _ firstIndex.
	[index <= lastIndex]
		whileTrue: 
			[(aBlock value: (array at: index))
				ifTrue: [self removeIndex: index]
				ifFalse: [index _ index + 1]]