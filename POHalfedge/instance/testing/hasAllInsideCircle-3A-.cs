hasAllInsideCircle: aCollection 
	"Tests if all Points in aCollection are inside the circle which has this  
	edge as a diameter"
	aCollection do: [:aPoint | (self origin - aPoint dotProduct: self destination - aPoint)
			> 0 ifTrue: [^ false]].
	^ true