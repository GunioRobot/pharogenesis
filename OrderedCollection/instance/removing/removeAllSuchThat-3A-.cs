removeAllSuchThat: aBlock 
	"Evaluate aBlock for each element of the receiver. Remove each element 	for which aBlock evaluates to true. Answer an OrderedCollection of the 
	removed elements."
	| index element newCollection |
	newCollection _ self species new.
	index _ firstIndex.
	[index <= lastIndex]
		whileTrue: 
			[element _ array at: index.
			(aBlock value: element)
				ifTrue: 
					[newCollection add: element.
					self removeIndex: index]
				ifFalse: [index _ index + 1]].
	^newCollection