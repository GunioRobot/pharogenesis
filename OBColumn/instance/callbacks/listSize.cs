listSize
	^ children
		ifNil: [0]
		ifNotNil: [children size]