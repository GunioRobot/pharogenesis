positionDirectionShaft: aPolygon
	"Position the polygon, and return an array holding the coordinates of the tip and the heading in radians."
	| alphaRadians arrowVector tipLocation |
	"Pretty crude and slow approach at present, but a stake in the ground"
	alphaRadians _ target assuredPlayer getHeading degreesToRadians.
	arrowVector _ self directionArrowLength * (alphaRadians sin  @ alphaRadians cos negated).
	aPolygon setVertices: 
		(Array with: directionArrowAnchor
			with: (tipLocation _ directionArrowAnchor + arrowVector)).
	^ Array with: tipLocation with: alphaRadians
