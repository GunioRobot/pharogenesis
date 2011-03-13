nudgeForLabel: aRectangle
	"Try to move the label off me. Prefer labels on the top and right."

	| i flags nudge |
	(self bounds intersects: aRectangle) ifFalse: [^ 0@0 ].
	flags _ 0.
	nudge _ 0@0.
	i _ 1.
	aRectangle lineSegmentsDo: [ :rp1 :rp2 | | rectSeg int |
		rectSeg _ LineSegment from: rp1 to: rp2.
		self straightLineSegmentsDo: [ :lp1 :lp2 | | polySeg  |
			polySeg _ LineSegment from: lp1 to: lp2.
			int _ polySeg intersectionWith: rectSeg.
			int ifNotNil: [ flags _ flags bitOr: i ].
		].
		i _ i * 2.
	].
	"Now flags has bitflags for which sides"
	nudge _ flags caseOf: {
"no intersection"
		[ 0 ] -> [ 0@0 ].
"2 adjacent sides only" 
		[ 9 ] -> [ 1@1 ].
		[ 3 ] -> [ -1@1 ].
		[ 12 ] -> [ 1@-1 ].
		[ 6 ] -> [ -1@-1 ].
"2 opposite sides only" 
		[ 10 ] -> [ 0@-1 ].
		[ 5 ] -> [ 1@0 ].
"only 1 side" 
		[ 8 ] -> [ -1@0 ].
		[ 1 ] -> [ 0@-1 ].
		[ 2 ] -> [ 1@0 ].
		[ 4 ] -> [ 0@1 ].
"3 sides" 
		[ 11 ] -> [ 0@1 ].
		[ 13 ] -> [ 1@0 ].
		[ 14 ] -> [ 0@-1 ].
		[ 7 ] -> [ -1@0 ].
 "all sides" 
		[ 15 ] -> [ 1@-1 "move up and to the right" ].
	}.
	^nudge