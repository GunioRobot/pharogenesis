position: p
	| r side p1 corners c1 c2 sideIndex |
	"Adhere to owner bounds, and apply gridding"
	r _ owner bounds.
	side _ r sideNearestTo: p.
	p1 _ r pointNearestTo: p.  "a point on the border"
	p1 _ p1 grid: 4@4.

	"Update pin spec(5) = side index + fraction along side"
	corners _ r corners.
	sideIndex _ #(left bottom right top) indexOf: side.
	c1 _ corners at: sideIndex.
	c2 _ corners atWrap: sideIndex+1.
	pinSpec pinLoc: sideIndex + ((p1 dist: c1) / (c2 dist: c1) min: 0.99999).

	"Set new position with appropriate offset."
	side = #top ifTrue: [super position: p1 - (0@8)].
	side = #left ifTrue: [super position: p1 - (8@0)].
	side = #bottom ifTrue: [super position: p1].
	side = #right ifTrue: [super position: p1].

	wires do: [:w | w pinMoved]