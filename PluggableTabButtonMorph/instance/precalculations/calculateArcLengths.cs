calculateArcLengths
	| array radius |
	radius _ self cornerRadius.
	array _ Array new: radius.
	
	1 to: radius do: [ :i | | x |
		x _ i - 0.5.
		array at: i
		 	put: (radius - ((2 * x * radius) - (x * x)) sqrt) asInteger].
		
	self arcLengths: array