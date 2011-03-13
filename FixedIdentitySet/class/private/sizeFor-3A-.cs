sizeFor: aCollection
	^ aCollection species == self 
		ifTrue: [aCollection capacity]
		ifFalse: [self defaultSize].