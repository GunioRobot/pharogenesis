transformedBy: aTransformer
	^(super transformedBy: aTransformer) position: (aTransformer transformPosition: position)