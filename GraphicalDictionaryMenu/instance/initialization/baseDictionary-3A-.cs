baseDictionary: aDictionary
	baseDictionary _ aDictionary.
	entryNames _ aDictionary keys asSortedArray.
	formChoices _ entryNames collect: [:n | aDictionary at: n].
	currentIndex _ 1