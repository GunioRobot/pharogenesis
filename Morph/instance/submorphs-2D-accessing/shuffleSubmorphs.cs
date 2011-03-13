shuffleSubmorphs
	"Randomly shuffle the order of my submorphs.  Don't call this method lightly!"

	| bg |
	self invalidRect: self fullBounds.
	(submorphs size > 0 and: [submorphs last mustBeBackmost]) ifTrue:
		[bg _ submorphs last.
		bg privateDelete].
	submorphs _ submorphs shuffled.
	bg ifNotNil: [self addMorphBack: bg].
	self layoutChanged