writeOn: aStream elementWriter: aBlock
	aStream binary.
	self keysAndValuesDo: [:categoryName :items |
		aStream nextStringPut: categoryName.
		items writeOn: aStream elementWriter: aBlock].