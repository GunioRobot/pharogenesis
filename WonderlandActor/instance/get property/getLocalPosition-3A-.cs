getLocalPosition: aVector
	"Return the local position of the given vector"
	| vv cc |
	vv _ B3DVector3 x: (aVector at: 1) y: (aVector at: 2) z: (aVector at: 3).
	cc _ composite composeWith: scaleMatrix.
	vv _ cc inverseTransformation localPointToGlobal: vv.
	^(Array with: vv x with: vv y with: vv z)