writeOn: aStream elementWriter: aBlock
	aStream binary.
	aStream nextInt32Put: contents size.
	contents keysAndValuesDo: [:x :count |
		aStream nextInt32Put: count.
		aBlock value: aStream value: x.
	].