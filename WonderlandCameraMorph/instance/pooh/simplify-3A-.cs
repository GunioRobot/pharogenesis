simplify: pointList
	| pts |
	pts _ StrokeSimplifier new.
	pointList do:[:aPoint| pts add: aPoint].
	pts closeStroke.
	^pts finalStroke.
