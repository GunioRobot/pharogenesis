nextPutAll: aCollection
	| start count max |
	aCollection species = collection species
		ifFalse:[
			aCollection do:[:ch| self nextPut: ch].
			^aCollection].
	start _ 1.
	count _ aCollection size.
	[count = 0] whileFalse:[
		position = writeLimit ifTrue:[self deflateBlock].
		max _ writeLimit - position.
		max > count ifTrue:[max _ count].
		collection replaceFrom: position+1
			to: position+max
			with: aCollection
			startingAt: start.
		start _ start + max.
		count _ count - max.
		position _ position + max].
	^aCollection