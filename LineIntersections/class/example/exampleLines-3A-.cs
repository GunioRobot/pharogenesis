exampleLines: n
	"LineIntersections exampleLines: 100"
	| segments rnd canvas intersections pt p1 p2 |
	rnd _ Random new.
	segments _ (1 to: n) collect:[:i|
		p1 _ (rnd next @ rnd next * 500) asIntegerPoint.
		[p2 _ (rnd next @ rnd next * 200 - 100) asIntegerPoint.
		p2 isZero] whileTrue.
		LineSegment from: p1 to: p1 + p2].
	canvas _ Display getCanvas.
	canvas fillRectangle: (0@0 extent: 600@600) color: Color white.
	segments do:[:seg|
		canvas line: seg start to: seg end width: 1 color: Color black.
	].
	intersections _ LineIntersections of: segments.
	intersections do:[:array|
		pt _ array at: 1.
		canvas fillRectangle: (pt asIntegerPoint - 2 extent: 5@5) color: Color red].
	Display restoreAfter:[].