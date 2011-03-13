initWithContents: anObject prior: priorMorph forList: hostList indentLevel: newLevel

	super initWithContents: anObject prior: priorMorph forList: hostList indentLevel: newLevel.
	self width: hostList width.
	complexContents withoutListWrapper firstDisplay ifTrue: [
		complexContents withoutListWrapper firstDisplayedOnLevel: indentLevel.
		isExpanded _ true.
	].
	complexContents withoutListWrapper showInOpenedState ifTrue: [
		isExpanded _ true.
	].
	self addMorph: self repositionText.

