positionDirectionShaft: shaft
	"Position the shaft."
	| alphaRadians unitVector |
	"Pretty crude and slow approach at present, but a stake in the ground"
	alphaRadians _ target heading degreesToRadians.
	unitVector _ alphaRadians sin  @ alphaRadians cos negated.
	shaft setVertices: {unitVector * 6 + directionArrowAnchor.  "6 = radius of deadeye circle"
					unitVector * self directionArrowLength + directionArrowAnchor}
