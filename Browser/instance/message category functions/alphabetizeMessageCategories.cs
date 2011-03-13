alphabetizeMessageCategories
	classListIndex = 0 ifTrue: [^ false].
	self okToChange ifFalse: [^ false].
	Smalltalk changes reorganizeClass: self selectedClassOrMetaClass.
	self classOrMetaClassOrganizer sortCategories.
	self clearUserEditFlag.
	self editClass.
	self classListIndex: classListIndex.
	^ true