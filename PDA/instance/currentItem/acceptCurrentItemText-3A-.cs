acceptCurrentItemText: aText

	currentItem ifNil:
		[PopUpMenu notify: 'Can''t accept -- no item is selected'. ^ false].
	viewDescriptionOnly ifTrue:
		[currentItem description: aText string. ^ true].

	currentItem readFrom: aText.
	(currentItem isKindOf: PDAEvent) ifTrue: [self updateScheduleList].
	(currentItem isMemberOf: PDAToDoItem) ifTrue: [self updateToDoList].
	(currentItem isMemberOf: PDAPerson) ifTrue: [self updatePeopleList].
	(currentItem isMemberOf: PDARecord) ifTrue: [self updateNotesList].
	^ true