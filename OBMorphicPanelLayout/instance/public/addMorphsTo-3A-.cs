addMorphsTo: aMorph
	self addNavMorphTo: aMorph.
	(panels size > 1) ifTrue: [self addOtherMorphsTo: aMorph].
	