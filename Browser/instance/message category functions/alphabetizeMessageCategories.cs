alphabetizeMessageCategories
	classListIndex = 0
		ifTrue: [^ false].
	self okToChange ifFalse: [^ false].
	Smalltalk changes reorganizeClass: self selectedClassOrMetaClass.
	self classOrMetaClassOrganizer categories: self rawMessageCategoryList asSortedCollection asArray.
	self clearUserEditFlag.
	self editClass.
	self classListIndex: classListIndex.
	^ true