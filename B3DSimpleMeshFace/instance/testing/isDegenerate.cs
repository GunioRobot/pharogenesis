isDegenerate
	self size = 3 ifFalse:[^false].
	(self at: 1) position = (self at: 2) position ifTrue:[^true].
	(self at: 2) position = (self at: 3) position ifTrue:[^true].
	(self at: 1) position = (self at: 3) position ifTrue:[^true].
	^false