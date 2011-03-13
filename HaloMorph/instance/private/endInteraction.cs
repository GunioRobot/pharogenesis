endInteraction

	| m |
	(target isInWorld not or: [owner == nil]) ifTrue: [^ self].
	[target isFlexMorph and: [target hasNoScaleOrRotation]]
		whileTrue: [
			m _ target firstSubmorph.
			target removeFlexShell.
			target _ m].
	self isInWorld ifTrue: [self addHandles].
