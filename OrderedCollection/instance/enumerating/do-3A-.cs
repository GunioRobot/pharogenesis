do: aBlock 
	"Override the superclass for performance reasons."
	| index |
	index _ firstIndex.
	[index <= lastIndex]
		whileTrue: 
			[aBlock value: (array at: index).
			index _ index + 1]