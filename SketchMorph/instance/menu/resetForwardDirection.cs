resetForwardDirection
	| existingSetup aPlayer |
	existingSetup _ self setupAngle.
	self setupAngle: 0.
	(aPlayer _ self topRendererOrSelf player) ifNotNil:
		[aPlayer turn: existingSetup negated].
	self layoutChanged.
	self changed