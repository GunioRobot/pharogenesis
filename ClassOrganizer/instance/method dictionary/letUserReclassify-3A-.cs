letUserReclassify: anElement
	"Put up a list of categories and solicit one from the user.  Answer true if user indeed made a change, else false"
	"ClassOrganizer organization letUserReclassify: #letUserReclassify:"
	| currentCat newCat |
	currentCat _ self categoryOfElement: anElement.
	newCat _ self categoryFromUserWithPrompt: 'Choose Category (currently "', currentCat, '")'.
	(newCat ~~ nil and: [newCat ~= currentCat])
		ifTrue:
			[self classify: anElement under: newCat suppressIfDefault: false.
			^ true]
		ifFalse:
			[^ false]