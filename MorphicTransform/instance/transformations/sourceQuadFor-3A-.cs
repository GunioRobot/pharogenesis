sourceQuadFor: aRectangle
	^ aRectangle innerCorners collect: 
		[:p | self transform: p]