insideCircle: aPoint with: a with: b with: c
	"Returns TRUE if the point d is inside the circle defined by the
	points a, b, c. See Guibas and Stolfi (1985) p.107."
	^(((a dotProduct: a) * (self triArea: b with: c with: aPoint)) -
	((b dotProduct: b) * (self triArea: a with: c with: aPoint)) +
	((c dotProduct: c) * (self triArea: a with: b with: aPoint)) -
	((aPoint dotProduct: aPoint) * (self triArea: a with: b with: c))) > 0.0