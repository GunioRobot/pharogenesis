letUserReclassify: anElement in: aClass
	"Put up a list of categories and solicit one from the user.  
	Answer true if user indeed made a change, else false"
	

	| currentCat newCat |
	currentCat _ aClass organization categoryOfElement: anElement.
	newCat _ self 
				categoryFromUserWithPrompt: 'choose category (currently "', currentCat, '")' 
				for: aClass.
	(newCat ~~ nil and: [newCat ~= currentCat])
		ifTrue:
			[aClass organization classify: anElement under: newCat suppressIfDefault: false.
			^ true]
		ifFalse:
			[^ false]