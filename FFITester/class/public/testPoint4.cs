testPoint4 "FFITester testPoint4"
	"Test passing and returning up of structures > 64 bit"
	| pt1 pt2 pt3 |
	pt1 _ FFITestPoint4 new.
	pt1 x: 1. pt1 y: 2. pt1 z: 3. pt1 w: 4.
	pt2 _ FFITestPoint4 new.
	pt2 x: 5. pt2 y: 6. pt2 z: 7. pt2 w: 8.
	pt3 _ self ffiTestPoint4: pt1 with: pt2.
	(pt3 x = 6 and:[ pt3 y = 8 and:[pt3 z = 10 and:[pt3 w = 12]]]) 
		ifFalse:[self error:'Problem passing large structures'].
	^pt3