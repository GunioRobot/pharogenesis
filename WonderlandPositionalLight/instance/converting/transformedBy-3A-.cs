transformedBy: aTransformer

	^(super transformedBy: aTransformer)
			setPositionVector: (aTransformer transformPosition: (self getPositionVector)).
