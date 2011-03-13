updatePeopleList

	peopleList _ (allPeople select: [:c | c matchesKey: category]) sort.
	peopleListIndex _ peopleList indexOf: currentItem.
	self changed: #peopleListItems