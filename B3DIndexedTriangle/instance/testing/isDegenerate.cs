isDegenerate
	(self at: 1) = (self at: 2) ifTrue:[^true].
	(self at: 2) = (self at: 3) ifTrue:[^true].
	(self at: 3) = (self at: 1) ifTrue:[^true].
	^false