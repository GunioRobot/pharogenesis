computeFaceNormal
	| d1 d2 nrml |
	self size < 3 ifTrue:[^B3DVector3 zero].
	d1 _ (self at: 1) position - (self at: 2) position.
	d2 _ (self at: 3) position - (self at: 2) position.
	d1 safelyNormalize.
	d2 safelyNormalize.
	nrml _ d1 cross: d2.
	^nrml safelyNormalize