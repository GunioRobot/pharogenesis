onLineFrom: p1 to: p2 within: epsilon
	"Answer true if the receiver is on the line between p1 and p2
within a small epsilon plus half the line width."

	"test if receiver is within the bounding box"
	(((p1 rect: p2) expandBy: epsilon) containsPoint: self) ifFalse: [^ false].

	"it's in the box;  is it on the line?"
	^ (self dist: (self nearestPointAlongLineFrom: p1 to: p2)) <= epsilon