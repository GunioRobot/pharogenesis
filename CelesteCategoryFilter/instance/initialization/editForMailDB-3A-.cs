editForMailDB: mailDB
	| selections choiceIndex newName |
	selections := #('<type a name>') , mailDB allCategories.
	choiceIndex := (PopUpMenu  labelArray: selections)  startUp.
	choiceIndex = 0 ifTrue: [ ^self ].
	choiceIndex = 1
		ifTrue: [
			newName := FillInTheBlank request: 'category name?'.
			newName isEmpty ifTrue: [ ^self ] ]
		ifFalse: [ newName := selections at: choiceIndex ].

	categoryName := newName