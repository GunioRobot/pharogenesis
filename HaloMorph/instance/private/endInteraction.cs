endInteraction

	| m |
	(target isInWorld not or: [owner == nil]) ifTrue: [^ self].
	[target isFlexMorph and: [target hasNoScaleOrRotation]]
		whileTrue:
			[m _ target firstSubmorph.
			target removeFlexShell.
			target _ m].
	self isInWorld ifTrue:
		["make sure handles show in front, even if flex shell added"
		self comeToFront.
		self addHandles].
