computeVertexNormals
	| temp normals face normal v1 v2 v3 out |
	temp _ Array new: vertices size.
	1 to: temp size do:[:i| temp at: i put: B3DVector4 new].
	normals _ self faceNormals. "Forces computation if necessary"
	1 to: faces size do:[:i|
		face _ faces at: i.
		normal _ (normals at: i) asB3DVector4.
		v1 _ face p1Index.
		v2 _ face p2Index.
		v3 _ face p3Index.
		(temp at: v1) += normal.
		(temp at: v2) += normal.
		(temp at: v3) += normal.
	].
	out _ B3DVector3Array new: vertices size.
	1 to: out size do:[:i|
		out at: i put: (temp at: i) asB3DVector3 safelyNormalize.
	].
	^out