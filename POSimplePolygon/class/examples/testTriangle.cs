testTriangle
	"SimplePolygon testTriangle"
	| sp |
	sp _ self new vertices: (OrderedCollection new add: 0 @ 0;
				 add: 10 @ 10;
				 add: 20 @ 0;
				 yourself).
	self inform: sp circulation asString