testPoint2 "FFITester testPoint2"
	"Test passing and returning up of structures >32bit and <= 64 bit"
	| pt1 pt2 pt3 |
	pt1 _ FFITestPoint2 new.
	pt1 x: 1. pt1 y: 2.
	pt2 _ FFITestPoint2 new.
	pt2 x: 3. pt2 y: 4.
	pt3 _ self ffiTestPoint2: pt1 with: pt2.
	(pt3 x = 4 and:[ pt3 y = 6]) 
		ifFalse:[self error:'Problem passing 64bit structures'].
	^pt3