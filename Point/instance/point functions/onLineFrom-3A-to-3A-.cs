onLineFrom: p1 to: p2

	"Answer true if the receiver is on the line between p1 and p2 within a small epsilon. P1 is assumed to be to the left of p2."

	| origin corner normalizedP2 normalizedPt computed |

	"test if receiver is within the bounding box"
	p1 y > p2 y
		ifTrue: [origin _ p1 x @ p2 y.
				corner _ p2 x @ p1 y]
		ifFalse: [origin _ p1.
				corner _ p2.].
	(((origin corner: corner) insetBy: -3) containsPoint: self) ifFalse: [^ false].

	"its in the box, is it on the line?"
	(origin isRectilinear: corner) ifTrue: [^ true].

	normalizedP2 _ p2 - p1.
	normalizedPt _ self - p1.
	normalizedP2 x abs < normalizedP2 y abs
		ifTrue: [computed _ normalizedP2 x * normalizedPt y / normalizedP2 y asInteger.
				^ (normalizedPt x < (computed + 3)) & (normalizedPt x > (computed - 3))]
		ifFalse: [computed _ normalizedP2 y * normalizedPt x / normalizedP2 x asInteger.
				^ (normalizedPt y < (computed + 3)) & (normalizedPt y > (computed - 3))]