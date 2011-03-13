endInteraction
	"Clean up after a user interaction with the a halo control"

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
	(self valueOfProperty: #commandInProgress) doIfNotNil:
		[:cmd | self rememberCommand: cmd.
		self removeProperty: #commandInProgress] 
