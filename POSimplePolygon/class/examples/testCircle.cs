testCircle
	"SimplePolygon testCircle"
	| sp |
	sp _ self new vertices: (OrderedCollection new add: 0 @ 50;
				 add: 100 @ 10;
				 add: 200 @ 100;
				 add: 120 @ 300;
				 yourself).
	"add: 150 @ 320;"
	"add: 140 @ 20;"
	self inform: sp circulation asString