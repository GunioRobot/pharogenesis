removeEmptyCategories
	messageCategoryListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	self selectedClassOrMetaClass organization removeEmptyCategories.
	self changed: #messageCategoryList
