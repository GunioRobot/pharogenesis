simplify: pointList
	| pts |
	pts _ StrokeSimplifier new.
	points do:[:aPoint| pts add: aPoint].
	pts closeStroke.
	^pts finalStroke.
