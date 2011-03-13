previousCategory
	"Change the receiver to point at the category preceding the one currently seen"

	| aList anIndex newIndex already aChoice |
	aList _ scriptedPlayer categoriesForViewer: self.
	already _ self outerViewer ifNil: [#()] ifNotNil: [self outerViewer categoriesCurrentlyShowing].
	anIndex _ aList indexOf: self currentCategory ifAbsent: [aList size + 1].
	newIndex _ anIndex = 1
		ifTrue:		[aList size]
		ifFalse:		[anIndex - 1].
	[already includes: (aChoice _ aList at: newIndex)] whileTrue:
		[newIndex _ newIndex = 1 ifTrue: [aList size] ifFalse: [newIndex - 1]].

	self categoryChoice: aChoice