endInteraction
	"Clean up after a user interaction with the a halo control"

	| m |
	self isMagicHalo: false.	"no longer"
	self magicAlpha: 1.0.
	(target isInWorld not or: [owner isNil]) ifTrue: [^self].
	[target isFlexMorph and: [target hasNoScaleOrRotation]] whileTrue: 
			[m := target firstSubmorph.
			target removeFlexShell.
			target := m].
	self isInWorld 
		ifTrue: 
			["make sure handles show in front, even if flex shell added"

			self comeToFront.
			self addHandles].
	(self valueOfProperty: #commandInProgress) ifNotNilDo: 
			[:cmd | 
			self rememberCommand: cmd.
			self removeProperty: #commandInProgress]