gently: x lowerBound: A upperBound: B
	"This method converts a linear proportion done to a slow in - slow out proportion. If x is less than A then the animation is in the slow in part, while if x is greater than B then the animation is in the slow out part."

	| y a3 b3 c3 m b2 |
 
 	(x < A) ifTrue: [ y _ ((B - 1)/(A *  ((B * B) - (A * B) + A - 1))) * x * x ]
		    ifFalse: [ (x > B) ifTrue: [
										a3 _ 1 / ((B * B) - (A * B) + A - 1).
										b3 _ -2 * a3.
										c3 _ 1 + a3.
  										y _ (a3 * x * x) + (b3 * x) + c3.
									]
							ifFalse: [
										m _ 2 * (B - 1) / ((B * B) - (A * B) + A - 1).
										b2 _ (0 - m) * A / 2.
										y _ m * x + b2.
									].
  				    ].

	^ y.
