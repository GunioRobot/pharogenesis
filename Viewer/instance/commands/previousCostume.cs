previousCostume
	| aList aPlayer itsCurrent anIndex newIndex |
	aList _ (aPlayer _ scriptedPlayer) availableCostumesForArrows.
	aList isEmptyOrNil ifTrue: [^ Beeper beep].
	itsCurrent _ aPlayer costume renderedMorph.
	anIndex _ aList indexOf: itsCurrent ifAbsent: [nil].
	newIndex _ anIndex
		ifNil:		[aList size]
		ifNotNil:	[anIndex - 1].
	newIndex < 1 ifTrue: [newIndex _ aList size].
	aPlayer renderedCostume: (aList at: newIndex).
	self presenter ifNotNil: [self presenter updateViewer: self]