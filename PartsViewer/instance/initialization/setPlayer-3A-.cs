setPlayer: aPlayer
	| topRight |
	topRight _ bounds topRight.
	scriptedPlayer _ aPlayer.
	self removeAllMorphs.

	self addMorphBack: self rowBeforeParts.
	self addTilesForPlayerParts.
	self  addTransparentSpacerOfSize: 1 @ 8.
	self addMorphBack: self rowBeforeScripts.
	self addMorphBack: self commandTilesPartsBin.

	self isInWorld ifTrue: [self world startSteppingSubmorphsOf: self].
	self extent: 174@342.  "try to match size of BookMorphs"
	self position: (topRight x - self fullBounds width) @ topRight y.
	self beRepelling