intersectionsWith: aRectangle
	"Answer a Set of points where the given Rectangle intersects with me.
	Ignores arrowForms."

	| retval |
	retval _ IdentitySet new: 4.
	(self bounds intersects: aRectangle) ifFalse: [^ retval].

	self lineSegmentsDo: [ :lp1 :lp2 | | polySeg |
		polySeg _ LineSegment from: lp1 to: lp2.
		aRectangle lineSegmentsDo: [ :rp1 :rp2 | | rectSeg int |
			rectSeg _ LineSegment from: rp1 to: rp2.
			int _ polySeg intersectionWith: rectSeg.
			int ifNotNil: [ retval add: int ].
		].
	].

	^retval
