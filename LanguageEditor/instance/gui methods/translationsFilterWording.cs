translationsFilterWording
	^ (self translationsFilter isEmpty
		ifTrue: ['filter' translated]
		ifFalse: ['filtering: {1}' translated format:{self translationsFilter}]) 