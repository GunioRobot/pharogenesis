propertyAt: key ifAbsent: aBlock
	^properties
		ifNil: aBlock
		ifNotNil: [properties at: key ifAbsent: aBlock]