hasAllInsideCircle: aCollection 
	"Tests if all Points in aCollection are inside the circle which has this  
	edge as a diameter"
	| start end |
	start _ self origin.
	end _ self destination.
	aCollection do: [:aPoint | (start - aPoint dotProduct: end - aPoint)
			> 0 ifTrue: [^ false]].
	^ true