unclassifiedFrom: aCollection
	^ aCollection select: [:x | self isUnclassified: x]