reverseDo: aBlock 
	"Override the superclass for performance reasons."
	| index |
	index _ lastIndex.
	[index >= firstIndex]
		whileTrue: 
			[aBlock value: (array at: index).
			index _ index - 1]