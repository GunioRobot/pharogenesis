testFly
	"SimplePolygon testFly"
	| sp |
	sp _ self new vertices: (OrderedCollection new add: 0 @ 10;
				 add: 10 @ 0;
				 add: 19 @ 10;
				 add: 30 @ 20;
				 add: 40 @ 10;
				 add: 30 @ 0;
				 add: 21 @ 10;
				 add: 10 @ 20;
				 yourself).
	self inform: sp isSimple asString