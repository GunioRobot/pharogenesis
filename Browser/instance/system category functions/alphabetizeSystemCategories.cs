alphabetizeSystemCategories

	self okToChange ifFalse: [^ false].
	systemOrganizer sortCategories.
	self systemCategoryListIndex: 0.
	self changed: #systemCategoryList.
