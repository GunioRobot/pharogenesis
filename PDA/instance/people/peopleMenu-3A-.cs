peopleMenu: aMenu

	aMenu add: 'add new person' target: self selector: #addPerson.
	peopleListIndex > 0 ifTrue:
		[aMenu add: 'remove person' target: self selector: #removePerson].
	^ aMenu