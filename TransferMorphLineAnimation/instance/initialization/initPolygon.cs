initPolygon
	| polygonVertices |
	polygonVertices _ Array with: self transferMorph source bounds center with: self transferMorph bounds center.
	polygon _ PolygonMorphDashed
				vertices: polygonVertices
				color: Color transparent
				firstBorderWidth: 1
				secondBorderWidth: 1
				firstBorderColor: Color black
				secondBorderColor: Color white
				firstBorderStepWidth: 10
				secondBorderStepWidth: 10.
	self addMorph: polygon
"	aniMorph _ PluginAnimationMorph on: polygon.
	aniMorph animation: [:currentState :animatedMorph | 
			animatedMorph vertices at: 2 put: self transferMorph source center.
			animatedMorph computeBounds.
			animatedMorph swapColors]"
