computeFaceNormals
	| out face v1 v2 v3 d1 d2 normal |
	out _ B3DVector3Array new: faces size.
	1 to: faces size do:[:i|
		face _ faces at: i.
		v1 _ vertices at: face p1Index.
		v2 _ vertices at: face p2Index.
		v3 _ vertices at: face p3Index.
		d1 _ v3 - v1.
		d2 _ v2 - v1.
		d1 safelyNormalize.
		d2 safelyNormalize.
		normal _ d1 cross: d2.
		out at: i put: normal safelyNormalize.
	].
	^out