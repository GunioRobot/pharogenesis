transformedBy: aTransformer
	^(super transformedBy: aTransformer)
				setRotationVector: (aTransformer transformDirection: direction)