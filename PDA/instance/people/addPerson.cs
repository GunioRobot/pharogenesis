addPerson
	| newPerson |
	newPerson _ PDAPerson new key: self categorySelected; name: 'Last, First'.
	allPeople _ allPeople copyWith: newPerson.
	self currentItem: newPerson.
	self updatePeopleList