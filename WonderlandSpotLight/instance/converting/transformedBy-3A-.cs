transformedBy: aTransformer
	^(super transformedBy: aTransformer) 
		target: (aTransformer transformPosition: target).
