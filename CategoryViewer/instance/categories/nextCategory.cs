nextCategory
	"Change the receiver to point at the category following the one currently seen"

	| aList anIndex newIndex already aChoice |
	aList _ scriptedPlayer categoriesForViewer: self.
	already _ self outerViewer ifNil: [#()] ifNotNil: [self outerViewer categoriesCurrentlyShowing].
	anIndex _ aList indexOf: self currentCategory ifAbsent: [0].
	newIndex _ anIndex = aList size
		ifTrue:		[1]
		ifFalse:		[anIndex + 1].
	[already includes: (aChoice _ aList at: newIndex)] whileTrue:
		[newIndex _ (newIndex \\ aList size) + 1].
	self categoryChoice: aChoice