nextCostume
	| aList aPlayer itsCurrent anIndex newIndex |
	aList _ (aPlayer _ scriptedPlayer) availableCostumesForArrows.
	aList isEmptyOrNil ifTrue: [^ Beeper beep].
	itsCurrent _ aPlayer costume renderedMorph.
	anIndex _ aList indexOf: itsCurrent ifAbsent: [nil].
	newIndex _ anIndex
		ifNil:		[1]
		ifNotNil:	[anIndex + 1].
	newIndex > aList size ifTrue: [newIndex _ 1].
	aPlayer renderedCostume: (aList at: newIndex).
	self presenter ifNotNil: [self presenter updateViewer: self]