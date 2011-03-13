removePerson

	allPeople _ allPeople copyWithout: currentItem.
	self currentItem: nil.
	self updatePeopleList.
