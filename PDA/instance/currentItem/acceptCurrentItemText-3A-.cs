acceptCurrentItemText: aText
	"Accept into the current item from the text provided, and update lists accordingly"

	currentItem ifNil:
		[self inform: 'Can''t accept -- no item is selected'. ^ false].
	viewDescriptionOnly ifTrue:
		[currentItem description: aText string. ^ true].

	currentItem readFrom: aText.
	(currentItem isKindOf: PDAEvent) ifTrue: [self updateScheduleList].
	(currentItem isMemberOf: PDAToDoItem) ifTrue: [self updateToDoList].
	(currentItem isMemberOf: PDAPerson) ifTrue: [self updatePeopleList].
	(currentItem isMemberOf: PDARecord) ifTrue: [self updateNotesList].
	^ true